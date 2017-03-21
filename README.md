# NeuralNet
A basic neural network, with a user interface for testing. Implemented using C# 7.

This solution consists of 3 projects with their respective namespaces:

## NeuralNet.Configuration

### NeuralNet.Configuration.NeuralNetTask

Represents a task for the neural net to carry out. Includes such things as training data, number of neurons, and required accuracy to consider the neural net trained. This is an abstract class - it should be derived from to specify the appropriate attributes for the specific task.

### NeuralNet.Configuration.ConfiguredNeuralNetFactory

Each instance of this class is a factory that creates NeuralNetTask objects. The factory is created using a configuration file (specified in the constructor), and the contents of the configuration file are used to configure the NeuralNetTask objects that the factory creates.

The configuration file is an XML serialization of a NeuralNetConfig object.

### NeuralNet.Configuration.NeuralNetConfig

Configuration for a ConfiguredNeuralNetFactory object.

### NeuralNet.Configuration.NetInputOutputFormatter

A class with virtual methods which convert data from the format used by the neural network (floating point numbers between 0 and 1) to a format which is appropriate for the specific task. Optionally, an object of this type can be passed into the constructor of a NeuralNetTask by classes which are derived from NeuralNetTask.

## NeuralNetTypes

This namespace contains:

- A class called NeuralNetSqaure, which takes a number between 0 and 10, and calculates its square
- Two classes that derive from NetInputOutputFormatter. One formats Boolean data. The other accompanies the NeuralNetSquare class, and formats data specifically for this class.

## NeuralNetTester

A user interface for testing the neural network.

Additionally, this project contains some configuration files that can be used to create configured NeuralNetTask classes - one which performs a Boolean AND, and one which performas a Boolean XOR.

#### Credits

The algorithm for the neural network is based very heavily on [this algorithm from c-sharpcorner.com](http://www.c-sharpcorner.com/article/C-Sharp-artificial-intelligence-ai-programming-a-basic-object/).

Credit is also given to http://www.free-icons-download.net for the icon.
