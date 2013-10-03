using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace DayPredictor
{
    public partial class MainPage : PhoneApplicationPage
    {
        int fdate, fmonth, fyear,flag;
       int [] ddate={31,29,31,30,31,30,31,31,30,31,30,31};
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

       

        private void day_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                String val = ((TextBox)sender).Text;
                int date = Int32.Parse(val);
                if (date < 1 || date > 31)
                {
                    MessageBox.Show("Invalid date!");
                    daybox.Focus();
                }
                else { fdate = date;
                monthbox.Focus();
                }
            }
            catch (FormatException ej)
            {
            }
        }

        private void month_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                String val = ((TextBox)sender).Text;
                int month = Int32.Parse(val);
                if (month < 1 || month > 12)
                {
                    MessageBox.Show("Invalid month!");
                    monthbox.Focus();
                }
                else {
                    if (ddate[month - 1] >= fdate)
                    {
                        fmonth = month;
                        yearbox.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Enter date again!");
                            daybox.Focus();
                    }
                    
                 
            
                }
            }
            catch (FormatException rt)
            {
            }
        }

        private void year_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                String val = ((TextBox)sender).Text;
                int year = Int32.Parse(val);
                if (year < 1900 || year > 2100)
                {
                    MessageBox.Show("Year should be between 1900 & 2100!");
                    yearbox.Focus();
                }
                else { fyear = year; }
            }
            catch (FormatException annu)
            {
            }
        }

        private void finday_Click(object sender, RoutedEventArgs e)
        {
            int no_day=0,y1,leap,dday;
			no_day=fdate+Month(fmonth,fyear);	
			y1=fyear-1900;
			leap=(y1-1)/4;
			y1=(y1*365)+leap;
			no_day+=y1;
			dday=(no_day)%7;
            
			switch(dday)
				{
					case 0: answer.Text="SUNDAY"; break;
					case 1: answer.Text="MONDAY"; break;
					case 2: answer.Text="TUESDAY"; break;
					case 3: answer.Text="WEDNESDAY"; break;	
					case 4: answer.Text="THURSDAY"; break;
					case 5: answer.Text="FRIDAY"; break;
					case 6: answer.Text="SATURDAY"; break;
				}		
            if(flag==0)
                leapyearbox.Text = "NOT A LEAP YEAR";
            else
                leapyearbox.Text = "LEAP YEAR";

        }
        private int Month(int m1,int y1)
        {
			int days=0,m=m1,y=y1;
            if (m > 2)
            {
                if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0)
                {
                    flag = 1;
                    
                    days += 1;
                }

            }
            else
            {
                flag = 0;
                
            }
					//leap year					
			for(int i=1;i<m;i++)
				{
					if(i==1 || i==3 || i==5 || i==7 || i==8 || i==10 || i==12)
					{
						days+=31;
					}
					else{
						if(i==4 || i==6 || i==9 || i==11)
							{
								days+=30;
							}
						else{
							if(i==2){
								days+=28;
								}					
						}
					}
				}	//no of days in months

			return days;
				}
    }
}
