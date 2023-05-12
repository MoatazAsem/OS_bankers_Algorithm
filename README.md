# OS_bankers_Algorithm
# Banker's Algorithm Windows Forms Application

This is a Windows Forms application that implements the Banker's Algorithm for deadlock avoidance. The Banker's Algorithm is used to determine if a system is in a safe state by checking if there is a sequence of processes that can be executed without causing a deadlock and it show this sequance of the process.

## Requirements

To run this application, you need to have the .NET Framework installed on your computer. The specific version of the .NET Framework required is 5.0+.

...

## Usage

To use the application, follow these steps:

1. Launch the application by running the executable file `Banker_s_algorithm.exe`.
2. Enter the number of processes and resources in the corresponding text boxes.
3. Enter the allocation matrix, maximum matrix, and available resources in the corresponding text boxes. You can use spaces to separate the values.
4. To request additional resources for a specific process, enter the process number and the requested resources in the corresponding text boxes, then click the "Request Resources" button. The application will check if the request can be granted without causing a deadlock, and display the results in the "Safe Sequence" text box.
5. Click the Check Safe State "RUN" button to run the Banker's Algorithm and determine if the system is in a safe state. If it is, the safe sequence will be displayed in the "Safe Sequence" text box. If not, an error message will be displayed.

...

## License

This code is provided under the MIT License. See the `LICENSE` file for details.

## Credits

This application was developed by [Moataz Asem].