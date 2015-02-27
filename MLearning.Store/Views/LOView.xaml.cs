using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Cirrious.MvvmCross.WindowsCommon.Views;
using StackView;
using DataSource;
using MLearning.Core.ViewModels;
using Windows.UI.Xaml.Media.Imaging;
using MLearning.Store.Components;
using Windows.UI;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MLearning.Store.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LOView : MvxWindowsPage
    {
        BookDataSource booksource;
        IGroupList lo_list;
        ControlDownMenu menu;
        int _currentLO = 0;

        public LOView()
        {
            this.InitializeComponent();
            this.Loaded += LOView_Loaded;
        }

        async void LOView_Loaded(object sender, RoutedEventArgs e)
        {

            var vm = ViewModel as LOViewModel;
          

            initbackground();
            init();
        }



        void init()
        {
            booksource = new BookDataSource();
            lo_list = new IGroupList();

            lo_list.StackListScrollCompleted += lo_list_StackListScrollCompleted;
            MainGrid.Children.Add(lo_list);

            menu = new ControlDownMenu();
            MainGrid.Children.Add(menu);
            menu.ControlDownElementSelected += menu_ControlDownElementSelected;

            loadLOsInCircle(0);
            lo_list.Source = booksource;
            menu.Source = booksource;
            var vm = this.ViewModel as LOViewModel;
            vm.PropertyChanged += vm_PropertyChanged;

        }

        private void lo_list_StackListScrollCompleted(object sender, int nextitem)
        {
            menu.SelectElement(nextitem);
            booksource.TemporalColor = booksource.Chapters[nextitem].ChapterColor;
            _backgroundscroll.settoindex(nextitem);
            _menucontroller.Animate2Color(booksource.Chapters[nextitem].ChapterColor);
        }

        void menu_ControlDownElementSelected(object sender, int index)
        {
            lo_list.AnimateToChapter(index);
            var vm = ViewModel as LOViewModel; 
           // vm.LoadStackImagesCommand.Execute(index);
        }

        void vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var vm = this.ViewModel as LOViewModel;
            if (e.PropertyName == "LOsInCircle")
            {
                if (vm.LOsInCircle != null)
                {
                    vm.LOsInCircle.CollectionChanged += LOsInCircle_CollectionChanged;
                }
            }

        }



        void LOsInCircle_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            loadLOsInCircle(e.NewStartingIndex);
            var vm = ViewModel as LOViewModel;
            menu.SelectElement(vm.LOCurrentIndex);
            booksource.TemporalColor = Util.GetColorbyIndex(vm.LOCurrentIndex);
        }

        void loadLOsInCircle(int index)
        {
            var vm = ViewModel as LOViewModel;
            if (vm.LOsInCircle != null)
            {

                for (int i = index; i < vm.LOsInCircle.Count; i++)
                {
                    ChapterDataSource newchapter = new ChapterDataSource();
                    newchapter.Title = vm.LOsInCircle[i].lo.title;
                    newchapter.Author = vm.LOsInCircle[i].lo.name + "\n" + vm.LOsInCircle[i].lo.lastname;
                    newchapter.Description = vm.LOsInCircle[i].lo.description;
                    newchapter.ChapterColor = Util.GetColorbyIndex(i % 6);
                    newchapter.TemporalColor = Util.GetColorbyIndex(0);
                    // newchapter.BackgroundImage =
                    if (vm.LOsInCircle[i].background_bytes != null)
                        newchapter.BackgroundImage = Constants.ByteArrayToImageConverter.Convert(vm.LOsInCircle[i].background_bytes);

                    vm.LOsInCircle[i].PropertyChanged += (s1, e1) =>
                            {
                                if (e1.PropertyName == "background_bytes")
                                {
                                    newchapter.BackgroundImage = Constants.ByteArrayToImageConverter.Convert(vm.LOsInCircle[i].background_bytes);
                                }
                            };

                    //loading the stacks
                    if (vm.LOsInCircle[i].stack.IsLoaded)
                    {
                        var s_list = vm.LOsInCircle[i].stack.StacksList;
                        for (int j = 0; j < s_list.Count; j++)
                        {
                            SectionDataSource stack = new SectionDataSource();

                            stack.Name = s_list[j].TagName;
                            for (int k = 0; k < s_list[j].PagesList.Count; k++)
                            {
                                var page = new PageDataSource();
                                page.Name = s_list[j].PagesList[k].page.title;
                                page.Description = s_list[j].PagesList[k].page.description;
                                if (s_list[j].PagesList[k].cover_bytes != null)
                                    page.ImageContent = Constants.ByteArrayToImageConverter.Convert(s_list[j].PagesList[k].cover_bytes);


                             

                                s_list[j].PagesList[k].PropertyChanged += (s2, e2) =>
                                {
                                    if (e2.PropertyName == "cover_bytes")
                                        page.ImageContent = Constants.ByteArrayToImageConverter.Convert((s2 as MLearning.Core.ViewModels.LOViewModel.page_wrapper).cover_bytes);//s_list[j].PagesList[k].cover_bytes);
                                };
                                stack.Pages.Add(page);
                            }
                            newchapter.Sections.Add(stack);
                        }

                    }
                    else
                    {

                        vm.LOsInCircle[i].stack.PropertyChanged += (s3, e3) =>
                            {
                                var s_list = vm.LOsInCircle[i].stack.StacksList;
                                for (int j = 0; j < s_list.Count; j++)
                                {
                                    SectionDataSource stack = new SectionDataSource();

                                    stack.Name = s_list[j].TagName;
                                    for (int k = 0; k < s_list[j].PagesList.Count; k++)
                                    {
                                        PageDataSource page = new PageDataSource();
                                        page.Name = s_list[j].PagesList[k].page.title;
                                        page.Description = s_list[j].PagesList[k].page.description;
                                        if (s_list[j].PagesList[k].cover_bytes != null)
                                            page.ImageContent = Constants.ByteArrayToImageConverter.Convert(s_list[j].PagesList[k].cover_bytes);

                                        //s_list[j].PagesList[k].i_id = i;
                                        //s_list[j].PagesList[k].j_id = j;
                                        //s_list[j].PagesList[k].k_id = k;

                                        s_list[j].PagesList[k].PropertyChanged += (s2, e2) =>
                                        {
                                            if (e2.PropertyName == "cover_bytes")
                                                page.ImageContent = Constants.ByteArrayToImageConverter.Convert(s_list[j].PagesList[k].cover_bytes);
                                        };
                                        stack.Pages.Add(page);
                                    }
                                    newchapter.Sections.Add(stack);
                                }
                            }; 
                    }
                    booksource.Chapters.Add(newchapter);
                }
                menu.SelectElement(vm.LOCurrentIndex);
                booksource.TemporalColor = Util.GetColorbyIndex(vm.LOCurrentIndex);
                _backgroundscroll.Source = booksource;
                _menucontroller.SEtColor(booksource.Chapters[vm.LOCurrentIndex].ChapterColor);
            }
        }

        #region Controls background

        ControlScrollView _backgroundscroll;
        UpMenuController _menucontroller;
        void initbackground()
        {
            _backgroundscroll = new ControlScrollView();
            MainGrid.Children.Add(_backgroundscroll);
            Canvas.SetZIndex(_backgroundscroll, -10);

            _menucontroller = new UpMenuController();
            MainGrid.Children.Add(_menucontroller);
            Canvas.SetZIndex(_menucontroller, 100);
        }

        #endregion




    }
}
