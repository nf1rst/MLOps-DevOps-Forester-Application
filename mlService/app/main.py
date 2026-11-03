import os
from typing import List

import mlflow.sklearn
from fastapi import FastAPI, HTTPException
from mlflow import MlflowClient
from pydantic import BaseModel

app = FastAPI()
NAME = "cover-classifier"

tracking_uri = os.getenv("MLFLOW_TRACKING_URI", "http://127.0.0.1:5000")

mlflow.set_tracking_uri(tracking_uri)

model = None
model_name_alias = "No model loaded yet"


def load_champion():
    global model, model_name_alias
    try:
        model = mlflow.sklearn.load_model(f"models:/{NAME}@champion")
        client = MlflowClient()
        version = client.get_model_version_by_alias(NAME, "champion")
        model_name_alias = f"{NAME}/ v{version.version} (champion)"
    except Exception as f:
        crown_first_champion()


def crown_first_champion():
    global model, model_name_alias
    try:
        client = MlflowClient()
        versions = client.search_model_versions(f"name='{NAME}'")

        if versions:
            latest_version = max(versions, key=lambda v: int(v.version))

            client.set_registered_model_alias(NAME, "champion", latest_version.version)

        model = mlflow.sklearn.load_model(f"models:/{NAME}@champion")
        model_name_alias = f"{NAME}/ v{latest_version.version} (champion)"
    except Exception as e:
        print(f"WARNING: Could not load the champion from crown_first_champion: {e}")


load_champion()


class InputData(BaseModel):
    Elevation: int
    Aspect: int
    Slope: int
    Horizontal_Distance_To_Hydrology: int
    Vertical_Distance_To_Hydrology: int
    Horizontal_Distance_To_Roadways: int
    Hillshade_9am: int
    Hillshade_Noon: int
    Hillshade_3pm: int
    Horizontal_Distance_To_Fire_Points: int
    Wilderness_Area: int
    Soil_Type: int


@app.get("/")
def home():
    return {
        "message": "The model is ready to be Nostradamus",
        "model ": model_name_alias,
    }


@app.post("/predict")
def predict(data: InputData):
    if model is None:
        load_champion()  # try again, maybe a champion exists now
    if model is None:
        raise HTTPException(status_code=503, detail="No champion model available yet")

    wilderness_area_binary = [
        1 if data.Wilderness_Area == i else 0 for i in range(1, 5)
    ]
    soil_binary = [1 if data.Soil_Type == i else 0 for i in range(1, 41)]

    sample = [
        [
            data.Elevation,
            data.Aspect,
            data.Slope,
            data.Horizontal_Distance_To_Hydrology,
            data.Vertical_Distance_To_Hydrology,
            data.Horizontal_Distance_To_Roadways,
            data.Hillshade_9am,
            data.Hillshade_Noon,
            data.Hillshade_3pm,
            data.Horizontal_Distance_To_Fire_Points,
            *wilderness_area_binary,
            *soil_binary,
        ]
    ]
    prediction = model.predict(sample)
    return {"prediction": int(prediction[0])}


# kopiert til Whatsapp
