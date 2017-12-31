﻿using System;
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

namespace Trivia.UI
{
    /// <summary>
    /// Interaction logic for QuizzardEndPage.xaml
    /// </summary>
    public partial class QuizzardEndPage : Page
    {
        public QuizzardEndPage(int points)
        {
            InitializeComponent();
            score.Text = points.ToString();
        }
    }
}