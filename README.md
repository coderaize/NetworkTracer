# NetworkTracer

## Overview

NetworkTracer is a Windows Forms application built with .NET that provides network diagnostic functionalities. It allows users to perform traceroutes to multiple IP addresses simultaneously, check port connectivity, and then visualize the results.

The application consists of two main components:

*   **ListTracer**: For initiating traceroutes and port checks on a list of IP addresses.
*   **FileTracer**: For parsing and displaying the traceroute results from the generated log files.

## Features

*   **Bulk Traceroute**: Perform traceroutes for a list of IP addresses.
*   **Customizable Parameters**: Set custom timeout and max hops for traceroutes.
*   **Port Scanning**: Check the status of a specific port on multiple IP addresses.
*   **Result Logging**: Saves detailed traceroute logs for each IP address.
*   **Route Visualization**: Parses and displays the hops from the traceroute logs.

## How to Use

### Step 1: Tracing a list of IPs (`ListTracer`)

1.  Launch the `NetworkTracer.exe` application. The main window that appears is the **ListTracer**.
2.  In the grid, enter the IP addresses you want to trace in the "IP" column.
3.  (Optional) You can specify a "MaxHops" and "TimeOut" value for each IP address. If left blank, default values will be used.
4.  Click the **Start Tracer** button.
5.  The application will start performing traceroutes for all the IPs in the list. The progress will be displayed in the window title.
6.  The "Status" column will show the ping response to the destination IP.
7.  Once the process is complete, a new directory named `Result [YYYY MM DD HH-mm-ss]` will be created in the application's directory. This folder will contain the detailed traceroute log file for each IP address.

#### Checking Port Connectivity

1.  Enter a port number in the textbox next to the **Port Start** button.
2.  Click **Port Start**.
3.  The "Status" column will be updated with the ping status and whether the specified port is open or not.

### Step 2: Analyzing the results (`FileTracer`)

1.  From the **ListTracer** window, click the **File Tracer** button. This will open the **FileTracer** window.
2.  In the **FileTracer** window, you need to provide the path to the results directory that was generated in Step 1. By default, the application will look for a folder in its own directory (e.g., `Result [2025 07 24 17-15-29]`). Make sure the textbox contains the correct path to the results folder.
3.  Add the same IP addresses to the grid that you traced in the **ListTracer**.
4.  Click the **Start** button.
5.  The application will read the corresponding log file for each IP address from the results directory, parse it, and display the IP address of each hop in the grid.

## Building from Source

1.  Clone the repository.
2.  Open `NetworkTracer.sln` in Visual Studio.
3.  Build the solution. The executable will be available in the `bin/Debug` or `bin/Release` folder.
