# This is a repository containing machine learning demos

## Structure
The projects in a solution are structured in folders according to the machine learning model type.
- Binary Classification
- Multi Class Classification
- Recommendation
- Regression
- Image Classification
- Object Detection

### Binary Classification
  The idea behind the binary classification project is to determine the sentiment of a commentary.
 Inside the BC folder there is .NET MAUI project which is used for this demo.
 Inside the project there is a pre-trained model which determines the sendiment of a input text.
 - The training data is taken from https://learn.microsoft.com/en-us/dotnet/machine-learning/tutorials/sentiment-analysis

### MultiClass Classification
The idea behind this demo is to categorize github issues based on their title and description.
Inside the folder there is 2 projects:
- GitHubIssueModelCreator
- IssueCategorizer

#### GitHubIssueModelCreator
It is a Console App used to generate a model. Every step for generating the model is described in the Program.cs
- The training data is taken from https://raw.githubusercontent.com/dotnet/samples/main/machine-learning/tutorials/GitHubIssueClassification/Data/issues_train.tsv
- The test data is taken from https://raw.githubusercontent.com/dotnet/samples/main/machine-learning/tutorials/GitHubIssueClassification/Data/issues_test.tsv

#### IssueCategorizer
This is a .NET MAUI project which consumes the multiclass classification model generated in the console application.
The model is copied in the ML folder  and is named as "model.zip".
