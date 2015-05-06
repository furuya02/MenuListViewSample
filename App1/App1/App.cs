using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1 {
    public class App : Application {
        public App() {
            MainPage = new MainPage();
        }
    }

    class MainPage : MasterDetailPage {
        public MainPage() {
            Master = new MasterPage(this);
            SetDetail("");
        }
        public void SetDetail(string title) {
            Detail = new NavigationPage(new DetailPage(title)) {
                BarBackgroundColor = Color.Red,
            };
            IsPresented = false;// hide MasterPage
        }
    }

    class MasterPage : ContentPage {
        

        public MasterPage(MainPage mainPage) {

            var mode = 0;

            Title = "dmy";
            Icon = "slideout.png";
            BackgroundImage = "image002.png";

            var icon = new Image() {
                Source = "image001.png",
                HorizontalOptions = LayoutOptions.Start,
            };

            var labelName = new Label {
                Text = "XXXX Z",
                FontSize = 12,
                TextColor = Color.White,
            };
            var labelEMail = new Label {
                Text = "XXXX.ZZZZ@gmail.com",
                FontSize = 10,
                TextColor = Color.White
            };

            var menu0 = new[] { "Primary", "Social", "Promotion", "Starred", "important" };
            var menu1 = new[] { "Add accunt", "Manage account" };
            var listView = new ListView {
                ItemsSource = menu0
            };
            listView.ItemTapped += (s, a) => {
                var title = (String)a.Item;
                mainPage.SetDetail(title);
            };

            var sw = new Image {
                Source = "image003.png",
                WidthRequest = 10,
                HeightRequest = 10,
                HorizontalOptions = LayoutOptions.EndAndExpand

            };
            // Create Gesture
            var gr = new TapGestureRecognizer();
            gr.Tapped += (s, e) => {
                mode = mode == 0 ? 1 : 0;
                sw.Source = (mode == 0) ? "image003.png" : "image004.png";
                listView.ItemsSource = (mode == 0) ? menu0 : menu1;
            };
            sw.GestureRecognizers.Add(gr);



            Content = new StackLayout() {
                Children = {
                    new StackLayout() {
                        Padding = new Thickness(0,Device.OnPlatform(20,0,0),0,0),
                        Children = { 
                            icon,
                            new StackLayout {
                              Padding = new Thickness(10,0,10,0),
                              Orientation  = StackOrientation.Horizontal,
                              Children = {
                                  new StackLayout {
                                    Children = {
                                        labelName,labelEMail
                                    }
                                  },
                                  sw
                              }
                            },listView
                        }
                    }
                }
            };
        }

    }

    class DetailPage : ContentPage {
        public DetailPage(string title) {
            BackgroundColor = Color.Silver;
            Content = new Label {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = title
            };

        }
    }
}
