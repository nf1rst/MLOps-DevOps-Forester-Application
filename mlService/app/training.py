import os

import mlflow
import mlflow.sklearn
from sklearn.datasets import fetch_covtype
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import accuracy_score, f1_score
from sklearn.model_selection import train_test_split

mlflow.set_tracking_uri(os.getenv("MLFLOW_TRACKING_URI", "http://127.0.0.1:5000"))

mlflow.set_experiment("coverType-classifier")


coverData = fetch_covtype()

X = coverData.data.astype("float32")
y = coverData.target

X_train, X_test, y_train, y_test = train_test_split(
    X, y, test_size=0.2, random_state=42
)

# training multiple models in the same script - https://find1dream.github.io/en/How_to_train_multiple_model_in_one_time_with_sklearn

model_name = "RFC"
model = RandomForestClassifier(
    n_estimators=50,  # fewer trees
    max_depth=20,  # stops trees from growing huge
    min_samples_leaf=5,  # smaller trees, less overfitting
    n_jobs=1,
    random_state=42,
)


# https://mlflow.openml.io/docs/latest/ml/traditional-ml/sklearn/guide/

with mlflow.start_run(run_name=model_name):
    model.fit(X_train, y_train)

    predictions = model.predict(X_test)

    acc = accuracy_score(y_test, predictions)
    macro_f1 = f1_score(y_test, predictions, average="macro")

    mlflow.log_param("Model_type", "Random Forrest Classifier")
    mlflow.log_param("n_estimators", 50)
    mlflow.log_param("max_depth", 20)
    mlflow.log_param("min_samples_leaf", 5)
    mlflow.log_param("n_jobs", 1)
    mlflow.log_param("random_state", 42)
    mlflow.log_metric("Accuracy", acc)
    mlflow.log_metric("Macro-f1", macro_f1)

    mlflow.sklearn.log_model(
        name=model_name,
        sk_model=model,
        registered_model_name="cover-classifier",
        skops_trusted_types=["sklearn.tree._tree.Tree"],
    )
