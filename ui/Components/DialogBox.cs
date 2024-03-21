﻿using System.Collections.ObjectModel;

namespace Screen_Manager_SOP_2
{
    internal class DialogBox : Box, IHasDimensions, IHasPosition
    {
        private readonly List<IFocusable> focusableElements = [];
        public DialogBox(Dimensions dim, Position pos, Alignment? align, string text, List<string> labelsInput, List<string> labelsComboBox, List<string> options) 
            : base(dim, pos)
        {
            // -- DialogBox Border
            _ = new Box(
                    dim, 
                    pos);

            // -- DialogBox Title
            Position textFieldPosition = new(
                        pos.Left + Margins.BorderHorizontalMarginDouble,
                        pos.Top + Margins.BorderVerticalMarginSingle);
            Dimensions textFieldDimensions = new(dim);
            textFieldDimensions.Width -= Margins.BorderHorizontalMarginDouble;
            textFieldDimensions.Height -= Margins.BorderHorizontalMarginDouble;
            _ = new Textfield(

                    pos: textFieldPosition, 
                    dim: textFieldDimensions, 
                    text: text, 
                    align: align);

            // -- Label Field Group
            Position labelGroupStartPos = new(
                    pos.Left + Margins.BorderHorizontalMarginDouble,
                    pos.Top + textFieldPosition.Top);
            Dimensions labelFieldDim = new(
                    Margins.DialogBoxWidth / 2 - Margins.BorderHorizontalMarginDouble,
                    Margins.ComboBoxHeight);
            List<string> combinedLabels = new(labelsInput);
            combinedLabels.AddRange(labelsComboBox);
            LabelFieldGroup labelFields = new(
                pos: labelGroupStartPos,
                dim: labelFieldDim,
                spacing: Margins.BorderVerticalMarginDouble,
                inputFields: labelsInput.Count,
                comboBoxes: labelsComboBox.Count,
                labels: combinedLabels);
            Position nextStartPosLabelFields = labelFields.GetNextStartPosition();

            // -- Accept and Cancel buttons
            int halfButtonWidth = Margins.ButtonWidth / 2;
            int centerLeftHalf = pos.Left + dim.Width / 4;
            int centerRightHalf = pos.Left + 3 * dim.Width / 4;

            Position cancelButtonPos = new(
                centerLeftHalf - halfButtonWidth,
                nextStartPosLabelFields.Top);
            Dimensions cancelButtonDim = new(
                Margins.ButtonWidth, Margins.ButtonHeight);
            Button cancelButton = new(
                pos: cancelButtonPos,
                dim: cancelButtonDim,
                label: "Cancel",
                action: CancelPress,
                align: Alignment.Center);

            Position acceptButtonPos = new(
                centerRightHalf - halfButtonWidth,
                nextStartPosLabelFields.Top);
            Dimensions acceptButtonDim = new(
                Margins.ButtonWidth, Margins.ButtonHeight);
            Button acceptButton = new(
                pos: acceptButtonPos,
                dim: acceptButtonDim,
                label: "Accept",
                action: AcceptPress,
                align: Alignment.Center);
            focusableElements.Add(cancelButton);
            focusableElements.Add(acceptButton);

            // -- Input Field Group
            Position inputGroupStartPos = new(
                    pos.Left + Margins.BorderHorizontalMarginDouble,
                    pos.Top + textFieldPosition.Top);
            Dimensions inputFieldDim = new(
                    Margins.DialogBoxWidth / 2 - Margins.BorderHorizontalMarginDouble,
                    Margins.ComboBoxHeight);
            InputFieldGroup inputFields = new(
                pos: inputGroupStartPos,
                dim: inputFieldDim,
                spacing: Margins.BorderVerticalMarginDouble,
                labels: labelsInput);
            Position nextStartPosInputFields = inputFields.GetNextStartPosition();
            focusableElements.AddRange(inputFields.GetInputFields());

            // -- ComboBox Group
            Position comboBoxPos = new(
                    nextStartPosInputFields.Left, 
                    nextStartPosInputFields.Top);
            Dimensions comboBoxDim = new(
                    Margins.DialogBoxWidth / 2 - Margins.BorderHorizontalMarginDouble,
                    Margins.ComboBoxHeight);
            ComboBoxGroup comboBoxes = new(
                pos: comboBoxPos,
                dim: comboBoxDim,
                labels: labelsComboBox,
                options: options,
                spacing: Margins.BorderVerticalMarginDouble);
            Position nextStartPosComboBoxes = comboBoxes.GetNextStartPosition();
            focusableElements.AddRange(comboBoxes.GetComboBoxes());
        }

        public void AddFocusableElement(IFocusable element)
        {
            focusableElements.Add(element);
        }

        public ReadOnlyCollection<IFocusable> GetFocusableElements()
        {
            return focusableElements.AsReadOnly();
        }

        void CancelPress()
        {

        }

        void AcceptPress()
        {

        }
    }
}