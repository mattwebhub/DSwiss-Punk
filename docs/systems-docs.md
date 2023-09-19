# System Documentation

## Overview

This is a .NET cross-platform application made with the latest MS technologies for creating Mobile applications. MAUI utilizes the core Xamarin architectural design and is being set as a continuation for Xamarin.

This system follows the Model-View-ViewModel (MVVM) 

User -> View -> ViewModel -> Model -> ViewModel -> View -> User

This architecture adheres to community best practices. The application consists of two screens: a product list screen and a product detail screen.

## Directory Structure

The application's directory structure will be organized as follows:

- **App**: The main folder containing the MVVM structure.
  - **Models**: Contains all the model classes that represent the data and the rules of the application.
  - **Views**: Contains all the view classes or XAML files that define the layout and appearance of the application.
  - **ViewModels**: Contains the classes that act as an interface between Model and View. They handle user interactions and update the model and view accordingly, creating a separate abstraction of the View which can be used for automated View testing.
  - **Services**: Contains classes that handle external interactions like API calls, database access, etc.
  - **Helpers**: Contains utility classes that provide common functionality throughout the application.

- **Resources**: Contains resources like images and styles that are used in the application.
  - **Images**: Contains all the image files used in the application.
  - **Styles**: Contains all the style (CSS/XAML) files used in the application.
- **Tests**: Contains all the unit tests and UI tests for the application.

## Error Handling

The application adheres to the following error handling strategy.

- **ViewModels**: Each ViewModel is responsible for catching and handling errors during the execution of its commands. If an error occurs, the ViewModel will log the error message and, if necessary, notify the user through a user-friendly message.

- **Services**: Services are responsible for handling errors during external operations like API calls or database access. If an error occurs, the service will throw an exception with a detailed error message. This exception will be caught and handled by the ViewModel that initiated the operation.

- **Global Error Handling**: In addition to the local error handling in ViewModels and Services, the application also has a global error handler. This handler catches any unhandled exceptions that might occur during the application's runtime. When an unhandled exception is caught, the global error handler will log the exception and display a generic error message to the user.

## Application Flow

1. **Product List Screen**: This is the initial screen of the application. It fetches a list of products from an API and displays them in a list format. Each list item is clickable and leads to the product detail screen.
2. **Product Detail Screen**: This screen is displayed when a product from the product list screen is selected. It fetches and displays detailed information about the selected product from the API.


## Installation and Setup

This application is a cross-platform application that is set to run in Android, iOS and Mac. Here are the steps to set up the application on these platforms:

### Prerequisites

- Install the latest version of Visual Studio 2022 with the .NET MAUI workload.
- For Android and iOS, install the necessary SDKs through the Visual Studio installer.
- For macOS, ensure you have a Mac with the necessary build tools installed.

### Building and Running the Application

1. **Clone the Repository**: Clone the application repository to your local machine using Git.

2. **Open the Solution**: Open the `.sln` file in Visual Studio 2022 or Rider IDE.

3. **Restore NuGet Packages**: Right-click on the solution in Solution Explorer and select "Restore NuGet Packages".

4. **Set the Startup Project**: Right-click on the desired project (Android, iOS, or macOS) and set it as the startup project.

5. **Build the Application**: Build the application by clicking on "Build" in the menu and then "Build Solution".

6. **Run the Application**: Run the application by pressing F5 or clicking on "Start Debugging" in the Debug menu.

### Deploying to a Device or Emulator

- **Android**: You can deploy the application to an Android device by enabling USB debugging on the device and selecting it in the Visual Studio toolbar. For an emulator, ensure you have one set up in the Android Device Manager.

- **iOS**: To deploy to an iOS device, you need to have a valid Apple Developer account and the device registered in your account. For an emulator, select the desired iOS simulator in the Visual Studio toolbar.

- **macOS**: To run the application on macOS, ensure you have the necessary provisioning profiles set up in your Apple Developer account.

