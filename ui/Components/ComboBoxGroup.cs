using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Manager_SOP_2.ui.Components
{
    internal class ComboBoxGroup : DrawableObject
    {
        private Position StartPos { get; set; }
        private Dimensions FieldDim { get; set; }
        private int VerticalSpacing { get; set; }
        private List<ComboBox> ComboBoxes { get; set; }
        private List<string> Labels { get; set; }
        private Position NextStartPos { get; set; }

        public ComboBoxGroup(Position pos, Dimensions dim, List<string> labels, List<string> options, int spacing) : base(pos, dim)
        {
            this.StartPos = pos;
            this.FieldDim = dim;
            this.VerticalSpacing = spacing;
            this.ComboBoxes = [];
            this.Labels = labels;

            CreateComboBoxes(labels, options);
        }

        public void CreateComboBoxes(List<string> labels, List<string> options)
        {
            if (labels == null || labels.Count == 0)
                throw new ArgumentException("Labels collection cannot be null or empty.", nameof(labels));

            if (options == null || options.Count == 0)
                throw new ArgumentException("Options collection cannot be null or empty.", nameof(options));

            Position currentPos = Pos;

            foreach (var label in labels)
            {
                // -- ComboBox
                Position comboBoxPos = new(
                    currentPos.Left + Dim.Width,
                    currentPos.Top - Margins.BorderVerticalMarginSingle);
                ComboBox comboBox = new(
                    pos: comboBoxPos,
                    dim: new Dimensions(Dim.Width, Margins.ComboBoxHeight),
                    options: options);
                ComboBoxes.Add(comboBox);

                currentPos = new Position(
                    currentPos.Left,
                    currentPos.Top + Margins.ComboBoxHeight + VerticalSpacing);
            }
            NextStartPos = currentPos;
        }
        public Position GetNextStartPosition()
        {
            return NextStartPos;
        }
    }
}
