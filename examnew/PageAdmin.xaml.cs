using Npgsql;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NpgsqlTypes;

namespace examnew
{
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();

            BindingProduct();
            BindingCategory();
        }

        public void BindingProduct()
        {
            Binding binding = new Binding();    
            binding.Source = Connection.classProducts;
            lvProduct.SetBinding(ItemsControl.ItemsSourceProperty, binding);
            Connection.SelectProduct();
        }

        public void BindingCategory()
        {
            Binding binding = new Binding();
            binding.Source = Connection.classCategories;
            cbCategory.SetBinding(ItemsControl.ItemsSourceProperty, binding);
            Connection.SelectCategory();
        }
        public void clearinfo()
        {
            lvProduct.SelectedItem = null;
            tbName.Clear();
            tbComposition.Clear();
            cbCategory.Text = null;
            tbPhoto.Clear();
            tbPrice.Clear();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearinfo();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ClassProduct product = lvProduct.SelectedItem as ClassProduct;

            NpgsqlCommand cmd = Connection.GetCommand("update \"Product\" set \"Category\" = @categoty, \"Name\" = @name, \"Composition\" = @composition, \"Photo\" = @photo, \"Price\" = @price where \"Id\" = @id");
            cmd.Parameters.AddWithValue("@id", NpgsqlDbType.Integer, product.Id);
            cmd.Parameters.AddWithValue("@categoty", NpgsqlDbType.Varchar, cbCategory.Text.Trim());
            cmd.Parameters.AddWithValue("@name", NpgsqlDbType.Varchar, tbName.Text.Trim());
            cmd.Parameters.AddWithValue("@composition", NpgsqlDbType.Varchar, tbComposition.Text.Trim());
            cmd.Parameters.AddWithValue("@photo", NpgsqlDbType.Varchar, tbPhoto.Text.Trim());
            cmd.Parameters.AddWithValue("@price", NpgsqlDbType.Varchar, tbPrice.Text.Trim());

            var result = cmd.ExecuteNonQuery();
            if (result == 0) { MessageBox.Show("Данные не обновлены"); }
            else { MessageBox.Show("Данные обновлены"); }
            Connection.classProducts.Clear();
            BindingProduct();
            clearinfo();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ClassProduct product = lvProduct.SelectedItem as ClassProduct;

            NpgsqlCommand cmd = Connection.GetCommand("delete from \"Product\" where \"Id\" = @id");
            cmd.Parameters.AddWithValue("@id", NpgsqlDbType.Integer, product.Id);
            cmd.Parameters.AddWithValue("@category", NpgsqlDbType.Varchar, product.Category);
            cmd.Parameters.AddWithValue("@name", NpgsqlDbType.Varchar, product.Name);
            cmd.Parameters.AddWithValue("@composition", NpgsqlDbType.Varchar, product.Composition);
            cmd.Parameters.AddWithValue("@photo", NpgsqlDbType.Varchar, product.Photo);
            cmd.Parameters.AddWithValue("@price", NpgsqlDbType.Varchar, product.Price);
            var result = cmd.ExecuteNonQuery();

            if (result == 0) { MessageBox.Show("Данные не удалены"); }
            else { MessageBox.Show("Данные удалены"); }
            Connection.classProducts.Clear();
            BindingProduct();
            clearinfo();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NpgsqlCommand cmd = Connection.GetCommand("insert into \"Product\" (\"Category\", \"Name\", \"Composition\", \"Photo\", \"Price\")" +
                "values (@category, @name, @composition, @photo, @price)");
            cmd.Parameters.AddWithValue("@category", NpgsqlDbType.Varchar, cbCategory.Text.Trim());
            cmd.Parameters.AddWithValue("@name", NpgsqlDbType.Varchar, tbName.Text.Trim());
            cmd.Parameters.AddWithValue("@composition", NpgsqlDbType.Varchar, tbComposition.Text.Trim());
            cmd.Parameters.AddWithValue("@photo", NpgsqlDbType.Varchar, tbPhoto.Text.Trim());
            cmd.Parameters.AddWithValue("@price", NpgsqlDbType.Varchar, tbPrice.Text.Trim());
            var result = cmd.ExecuteNonQuery();

            if(result == 0) { MessageBox.Show("Данные не добавлены"); }
            else { MessageBox.Show("Данные добавлены"); }
            Connection.classProducts.Clear();
            BindingProduct();
            clearinfo();
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProduct.SelectedItem != null)
            {
                cbCategory.Text = (lvProduct.SelectedItem as ClassProduct).Category;
                tbName.Text = (lvProduct.SelectedItem as ClassProduct).Name;
                tbComposition.Text = (lvProduct.SelectedItem as ClassProduct).Composition;
                tbPhoto.Text = (lvProduct.SelectedItem as ClassProduct).Photo;
                tbPrice.Text = (lvProduct.SelectedItem as ClassProduct).Price;
            }
        }
    }
}
