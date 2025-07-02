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
    /// Логика взаимодействия для VisitsList.xaml
    /// </summary>
    public partial class VisitsList : Window
    {
        public VisitsList()
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
                        var data = await context.activation_history.ToListAsync();
                        var visits = new List<VisitInfo>();
                        foreach (var visit in data)
                        {
                            var pass = await context.pass.FirstOrDefaultAsync(p => p.Id == visit.pass_id);
                            var user = await context.user.FirstOrDefaultAsync(u => u.Id == pass.user_id);
                            visits.Add(new VisitInfo()
                            {
                                DateTimeVisit = visit.date_time_activation.ToString("dd.mm.yy hh:mm"),
                                FullNameOwner = $"{user.first_name} {user.last_name}",
                                Id = visit.Id
                            });
                        }
                        visitList.ItemsSource = visits;
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
