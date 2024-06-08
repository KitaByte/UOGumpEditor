# UOGumpEditor

UOGumpEditor is a versatile and powerful tool for creating, editing, and managing gumps (graphical user interface elements) for the Ultima Online game. This tool provides a user-friendly interface for both new and experienced developers to design and customize gumps easily.

## Features

- **Drag-and-Drop Interface**: Easily add and move elements on the canvas.
- **Element Layering**: Manage the z-order of elements to bring them to the front or send them to the back.
- **Image and Text Support**: Add images and text to your gumps, with customization options for fonts, colors, and alignment.
- **Background and Button Art**: Load and display background and button art assets.
- **Preview and Edit**: Preview the gump elements and edit their properties in real-time.
- **Save and Load**: Save your gump designs to files and load them back for further editing.

## Installation

To get started with UOGumpEditor, follow these steps:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/KitaByte/UOGumpEditor.git
   cd UOGumpEditor

2. **Install Dependencies**
Ensure you have .NET installed. You can download it from [here](https://dotnet.microsoft.com/download).

3. **Build the Project**
Open the solution file (`UOGumpEditor.sln`) in Visual Studio and build the project.

## Usage

### Main Interface
- **Canvas Panel**: This is where you design your gumps. You can drag and drop elements onto this panel.
- **Element Properties**: Select an element on the canvas to edit its properties, such as size, location, text, and image.
- **Toolbar**: Provides quick access to save, load, and export functions, as well as tools for adding different types of elements.

### Adding Elements
- **Drag and Drop**: Drag elements from the toolbox onto the canvas.
- **Adjust Properties**: Select an element to view and edit its properties in the properties panel.

### Managing Layers
- **Move Up/Down**: Use the context menu or toolbar buttons to move selected elements up or down in the z-order.

### Saving and Loading
- **Save Gump**: Save your current gump design to a file for later use.
- **Load Gump**: Load a previously saved gump file into the editor.

### Keyboard Shortcuts
- **Arrow Keys**: Move the selected element on the canvas.
- **Ctrl+S**: Save the current gump.
- **Ctrl+O**: Open a saved gump.

## Code Structure

### UOGumpEditor
The main application logic is contained in the `UOGumpEditor` namespace, including:
- **UOGumpEditorUI**: The main form class, handling the user interface.
- **UOEditorCore**: Core functionalities for managing elements and art assets.
- **ElementControl**: Custom control class for gump elements, supporting text and image rendering.

### UOGumps
Handles the serialization and deserialization of gump data:
- **BaseGump**: Represents a gump design, containing a list of `GumpElement` objects.
- **GumpElement**: Represents individual elements within a gump, including their properties and art data.

### Assets
Manages loading and accessing art assets used in gumps:
- **AssetData**: Static class providing access to gump and item art assets.

## Contributing
We welcome contributions! Please fork the repository and submit pull requests with your changes. Ensure your code follows the project's coding standards and includes appropriate tests.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Contact
For questions or feedback, please open an issue on GitHub or contact us at [https://www.uoopenai.com/wilson].
