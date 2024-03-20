using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using Screen_Manager_SOP_2;

Console.OutputEncoding = Encoding.UTF8;
Console.CursorVisible = false;
UserRepository userRepository = new();

// -- Main Window Border
Dimensions mainBoxDim = new(Console.WindowWidth, Console.WindowHeight);
Position mainBoxPos = new(0, 0);
Box MainBox = new(
        dim: mainBoxDim,
        pos: mainBoxPos);

// -- Main Window Title
_ = new Textfield(
        new Position(2, 1),
        dim: mainBoxDim,
        text: "CRUDapp",
        align: Alignment.Left,
        FG: ConsoleColor.Magenta);

// -- Main Window Button for creating new user
_ = new Button(
        new Position(
            MainBox.Pos.Left + Console.WindowWidth - Margins.ButtonWidth - Margins.BorderHorizontalMarginDouble,
            MainBox.Pos.Top + Margins.BorderVerticalMarginSingle),
        new Dimensions(
            Margins.ButtonWidth, Margins.ButtonHeight),
        label: "New User",
        align: Alignment.Center);

// -- Main Table
Position tablePos = new(
    mainBoxPos.Left + Margins.BorderHorizontalMarginDouble,
    mainBoxPos.Top + Margins.TableTopMargin);
Dimensions tableDim = new(
    mainBoxDim.Width - Margins.MainBoxBorderMargin,
    mainBoxDim.Height - Margins.TableBottomMargin);
List<string> headers = ["ID", "First Name", "Last Name", "Email", "Phone", "Address", "Title", "Delete", "Edit"];
List<User> users = userRepository.GetAllUsers();
Dictionary<int, int> columnAdjustments = new() { { 0, 4 }, { 7, 4 }, { 8, 4 } };
_ = new Table(
    pos: tablePos,
    dim: tableDim,
    headers: headers,
    users: users,
    columnAdjustments: columnAdjustments);

// -- Dialog Window Popup
/*Dimensions NewUserDialogBoxDim = new(
            Margins.DialogBoxWidth,
            Math.Min(Margins.DialogBoxHeight, Console.WindowHeight));
Position NewUserDialogBoxPos = new(
            (Console.WindowWidth - Margins.DialogBoxWidth) / 2,
            (Console.WindowHeight - Math.Min(Margins.DialogBoxHeight, Console.WindowHeight)) / 2);
_ = new DialogBox(
        dim: NewUserDialogBoxDim,
        pos: NewUserDialogBoxPos,
        align: Alignment.Center,
        text: "Create New User",
        labelsInput: ["First Name", "Last Name", "Email", "Phone", "Address"],
        labelsComboBox: ["Title"],
        options: ["Dev", "DevOps", "Support", "UX", "CEO"]);*/

// -- Edit Window Popup
/*Dimensions EditUserDialogBoxDim = new(
            Margins.DialogBoxWidth,
            Math.Min(Margins.DialogBoxHeight, Console.WindowHeight));
Position EditUserDialogBoxPos = new(
            (Console.WindowWidth - Margins.DialogBoxWidth) / 2,
            (Console.WindowHeight - Math.Min(Margins.DialogBoxHeight, Console.WindowHeight)) / 2);
_ = new DialogBox(
        dim: EditUserDialogBoxDim,
        pos: EditUserDialogBoxPos,
        align: Alignment.Center,
        text: "Edit User",
        labelsInput: ["First Name", "Last Name", "Email", "Phone", "Address"],
        labelsComboBox: ["Title"],
        options: ["Dev", "DevOps", "Support", "UX", "CEO"]);*/

// --
Console.ReadKey();  
