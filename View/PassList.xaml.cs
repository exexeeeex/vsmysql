using InterfaceDB.Data;
using InterfaceDB.Model;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для PassList.xaml
    /// </summary>
    public partial class PassList : Window
    {
        public PassList()
        {
            InitializeComponent();
            this.Loaded += (sender, e) => OnLoad();
        }

        public async void OnLoad()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    if (context.Database.CanConnect())
                    {
                        var data = context.pass.ToList();
                        if (data.Count < 1)
                        {
                            passesList.Visibility = Visibility.Hidden;
                            textNonInfo.Visibility = Visibility.Visible;
                        }
                        var passes = new List<PassInfo>();
                        foreach (var pass in data)
                        {
                            var user = await context.user.FirstOrDefaultAsync(u => u.Id == pass.user_id);
                            passes.Add(new PassInfo()
                            {
                                Id = pass.Id,
                                PassType = context.pass_type.FirstOrDefault(pt => pt.Id == pass.type_id)!.name,
                                Department = context.department.FirstOrDefault(d => d.Id == user.department_id)!.name,
                                FullNameOwner = $"{user.first_name} {user.last_name}",
                                IsActive = pass.is_active == 1 ? "Active" : "None Active" 
                            });
                        }
                        passesList.ItemsSource = passes;
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
