# C# OOP Fleet Management System 🚗

A console application built in C# to model and manage a fleet of vehicles. This project serves as a practical demonstration of fundamental Object-Oriented Programming (OOP) principles.

## Core Concepts Demonstrated

This project was built to showcase a strong understanding of the four pillars of OOP and related software design concepts:

-   **Inheritance:** A `HybridVehicle` class inherits from a base `Vehicle` class, sharing common attributes while also having its own unique properties (like battery capacity).
-   **Polymorphism:** The application manages a `List<Vehicle>` containing both `Vehicle` and `HybridVehicle` objects, treating them uniformly through the base class interface while invoking their specific overridden methods.
-   **Encapsulation:** Each class encapsulates its own data (private fields) and exposes functionality through public methods, hiding the internal complexity.
-   **Abstraction:** The base `Vehicle` class provides an abstract representation of a vehicle, defining a contract that all vehicle types must follow.
-   **Data Structures:** Utilizes the `List<T>` collection to efficiently store and iterate over the collection of vehicle objects.

## Features

-   Defines a clear class structure for different vehicle types.
-   Instantiates and manages a collection of diverse vehicles in a single list.
-   Calculates operational data for each vehicle, such as maximum travel range and trip feasibility.
-   Overrides the `ToString()` method to provide a clean, readable summary of each vehicle's status.

## Code Screenshot

Here is a glimpse of the main program structure, showing the instantiation of `Vehicle` and `HybridVehicle` objects.

<p align="center">
  <img src="https://www.valerkahere.com/assets/seesharp.png" alt="Screenshot of the C# code for the Fleet Management System" width="750">
</p>

## How to Run

### Prerequisites

-   [.NET SDK](https://dotnet.microsoft.com/en-us/download) (Version 6.0 or later)

### Steps

1.  **Clone the repository:**
    ```bash
    git clone <your-repository-url>
    ```

2.  **Navigate to the project directory:**
    ```bash
    cd <your-project-directory>
    ```

3.  **Build the project:**
    ```bash
    dotnet build
    ```

4.  **Run the application:**
    ```bash
    dotnet run
    ```

## Technologies Used

-   **C#**
-   **.NET**
