using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulklassenuebersicht
{
    interface GUI2
    {

        void GUI();

        void InitializeComponent();

        void SchoolClassesSelectedIndexChanged(object o, EventArgs e);

        void StudentSelectedIndexChanged(object o, EventArgs e);

        void BtnShowClick(object o, EventArgs e);

        void BtnAddClick(object o, EventArgs e);

        void BtnEditClick(object o, EventArgs e);

        void BtnDeleteClick(object o, EventArgs e);

        void BtnLinkClick(object o, EventArgs e);


    }
}
