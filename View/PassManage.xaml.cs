using InterfaceDB.Data;
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

namespace InterfaceDB.View
{
    /// <summary>
    /// Логика взаимодействия для PassManage.xaml
    /// </summary>
    public partial class PassManage : Window
    {
        public PassManage()
        {
            InitializeComponent();
        }

        private async void DeletePass_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(passNumber.Text, out var _)) MessageBox.Show("Номер не является числом!");
            try
            {
                using (var context = new AppDbContext())
                {
                    if (context.Database.CanConnect())
                    {
                        var pass = context.pass.FirstOrDefault(p => p.Id == int.Parse(passNumber.Text));
                        if (pass == null)
                        {
                            MessageBox.Show("Пропуск не найден!");
                            return;
                        }
                        context.pass.Remove(pass);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void OffPass_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(passNumber.Text, out var _)) MessageBox.Show("Номер не является числом!");
            try
            {
                using (var context = new AppDbContext())
                {
                    if (context.Database.CanConnect())
                    {
                        var pass = context.pass.FirstOrDefault(p => p.Id == int.Parse(passNumber.Text));
                        if (pass == null)
                        {
                            MessageBox.Show("Пропуск не найден!");
                            return;
                        }
                        pass.is_active = 0;
                        context.pass.Update(pass);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
