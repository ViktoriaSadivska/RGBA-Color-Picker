using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace exam.Model
{
    class ColorRepository
    {
        private static ObservableCollection<MyColor> _colors;
        public static ObservableCollection<MyColor> AllColors
        {
            get
            {
                if(_colors == null)
                {
                    _colors = CreateColorRepository();
                }
                return _colors;
            }
        }

        private static ObservableCollection<MyColor> CreateColorRepository()
        {
            ObservableCollection<MyColor> colors = new ObservableCollection<MyColor>();
            colors.Add(new MyColor(Colors.LightBlue.A, Colors.LightBlue.R, Colors.LightBlue.G, Colors.LightBlue.B));
            colors.Add(new MyColor(Colors.MistyRose.A, Colors.MistyRose.R, Colors.MistyRose.G, Colors.MistyRose.B));
            colors.Add(new MyColor(Colors.BlanchedAlmond.A, Colors.BlanchedAlmond.R, Colors.BlanchedAlmond.G, Colors.BlanchedAlmond.B));

            return colors;
        }
    }
}
