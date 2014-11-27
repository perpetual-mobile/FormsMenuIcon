﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormsMenuIcon
{
    public static class App
    {
        public static Page GetMainPage()
        {
            var MDPage = new MasterDetailPage();
            MDPage.Master = new ContentPage {
                Title = "Master",
                Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null,
                Content = new StackLayout {
                    Children = {
                        new Button {
                            Text = "Open detail A",
                            Command = new Command(o => {
                                MDPage.Detail = new NavigationPage(new CountingPage{ Title = "A" });
                                MDPage.IsPresented = false;
                            }),
                        },
                        new Button {
                            Text = "Open detail B",
                            Command = new Command(o => {
                                MDPage.Detail = new NavigationPage(new CountingPage{ Title = "B" });
                                MDPage.IsPresented = false;
                            }),
                        },
                    },
                },
            };
            MDPage.Detail = new NavigationPage(new CountingPage{ Title = "A" });
            return MDPage;
        }
    }

    class CountingPage: ContentPage
    {
        static int count;

        public CountingPage()
        {
            count++;
            Console.WriteLine("Constructor: " + count + " instances now");

            Content = new ListView {
                ItemsSource = new List<string> { "1", "2", "3" },
                ItemTemplate = new DataTemplate(typeof(CustomCell)),
            };
        }

        ~CountingPage()
        {
            count--;
            Console.WriteLine("Destructor: " + count + " instances now");
        }
    }

    public class CustomCell: ViewCell
    {
        Label label = new Label();

        public CustomCell()
        {
            label.SetBinding(Label.TextProperty, ".");
            View = label;
        }
    }
}
