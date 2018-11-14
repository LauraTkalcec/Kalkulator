using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2_vjezbe_kalkulator
{
    /// <summary>
    /// Interaction logic for kalk.xaml
    /// </summary>
    /// 

     //enumeracija
    enum Operacije { Zbrajanje, Oduzimanje, Mnozenje, Djeljenje, Nedefinirano};

    public partial class kalk : Window
    {
        //aktualna operacija
        private Operacije operacija = Operacije.Nedefinirano;

        //memorije broj
        private double pomocniBroj = 0;

        //broj koji se upisuje
        private double glavniBroj = 0;



        public kalk()
        {
            InitializeComponent();
        }

        public void OsvjeziEkran()
        {

        }

        private void pritisniBroj(object sender, RoutedEventArgs e)
        {
            glavniBroj *= 10;
            glavniBroj +=int.Parse(((Button)sender).Content.ToString());
            InicijalizacijaEkrana();
            
        }

        private void plusButton_click(object sender, RoutedEventArgs e)
        {
            OdabirOperacije(Operacije.Zbrajanje);
        }
        private void minus(object sender, RoutedEventArgs e)
        {
            OdabirOperacije(Operacije.Oduzimanje);
        }
        private void OdabirOperacije(Operacije _operacija)
        {
            //memoriramo operaciju
            operacija= _operacija;
            //preselimo glavni broj u pomocni
            pomocniBroj = glavniBroj;
            glavniBroj = 0;
            InicijalizacijaEkrana();
        }
        private void InicijalizacijaEkrana()
        {
            GlavniTextBox.Text = glavniBroj.ToString();
            PomocniTextBox.Text = pomocniBroj.ToString();
            //operacija na pomoćnom ekranu
            switch(operacija)
            {
                case Operacije.Zbrajanje:
                    PomocniTextBox.Text += "+";
                    break;
                case Operacije.Oduzimanje:
                    PomocniTextBox.Text += "-";
                    break;
                case Operacije.Mnozenje:
                    PomocniTextBox.Text += "*";
                    break;
                case Operacije.Djeljenje:
                    PomocniTextBox.Text += "/";
                    break;

            }
        }

        private void množenje(object sender, RoutedEventArgs e)
        {
            OdabirOperacije(Operacije.Mnozenje);
        }

        private void djeljenje(object sender, RoutedEventArgs e)
        {
            OdabirOperacije(Operacije.Djeljenje);
        }

        private void jednako(object sender, RoutedEventArgs e)
        {
            //PRVO PROVJERAVAM DA LI JE ZADANA OPERACIJA
            if (operacija != Operacije.Nedefinirano)
            {
                switch (operacija)
                {
                    case Operacije.Zbrajanje:
                        glavniBroj += pomocniBroj;
                        break;
                    case Operacije.Oduzimanje:
                        glavniBroj = pomocniBroj - glavniBroj;
                        break;
                    case Operacije.Mnozenje:
                        glavniBroj *= pomocniBroj;
                        break;
                    case Operacije.Djeljenje:
                        glavniBroj = pomocniBroj / glavniBroj;
                        break;
                }
                pomocniBroj = 0;
                InicijalizacijaEkrana();
            }
        }
    }
}
