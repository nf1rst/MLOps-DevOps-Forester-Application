import mlflow
from mlflow import MlflowClient

NAME = "cover-classifier"
client = MlflowClient()

versions = client.search_model_versions(f"name='{NAME}'")

latest = max(versions, key=lambda v: int(v.version))

latest_run = client.get_run(latest.run_id)
latest_model_macro = latest_run.data.metrics["Macro-f1"]

try:
    current_champion = client.get_model_version_by_alias(NAME, "champion")
    champion_run = client.get_run(current_champion.run_id)
    champion_macro = champion_run.data.metrics["Macro-f1"]

    if latest_model_macro > champion_macro + 0.02:
        # if there is a new champion,tag it with an alias champion
        # the current champion will loose the tag automatically
        client.set_registered_model_alias(NAME, "champion", latest.version)

    else:
        raise SystemExit(
            f"Quality gate failed: New macro-F1 ({latest_model_macro:.3f}) "
            f"did not beat baseline ({champion_macro:.3f}) + 0.02 "
            f"(Required: {champion_macro + 0.02:.3f})"
        )
except Exception:
    # if there are no champions currently,make the latest trained model the champion
    client.set_registered_model_alias(NAME, "champion", latest.version)


model = mlflow.pyfunc.load_model(f"models:/{NAME}@champion")
