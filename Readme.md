<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/NavigateCommandExample/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/NavigateCommandExample/MainWindow.xaml.vb))
* [MainWindow.xaml.cs](./CS/NavigateCommandExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/NavigateCommandExample/MainWindow.xaml.vb))
* [MainViewModel.cs](./CS/NavigateCommandExample/ViewModel/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/NavigateCommandExample/ViewModel/MainViewModel.vb))
<!-- default file list end -->
# How to hide non-working days in the Day view using custom commands and key handlers


This example demonstrates how to restrict the <a href="http://help.devexpress.com/#WPF/CustomDocument119204">Day View</a> navigation to display seven days, Saturday and Sunday excluded. <br>To accomplish this, the project implements a custom <a href="http://help_db/ReferenceBrowserMain_18_1/LoadItem.aspx?Member=D%3a113865&Template=CustomDocumentTopic">KeyToCommand behavior</a> to handle the left and right arrow keys. Navigation commands execute custom methods defined in ViewModel. Commands are replaced with methods using the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulingSchedulerControl_Commandstopic">SchedulerControl.Commands </a>property and <a href="https://documentation.devexpress.com/WPF/115776/MVVM-Framework/DXBinding/DXCommand">DXCommand</a> binding introduced in the DevExpress MVVM Framework . <br>A custom set of days is assigned to the <a href="http://help_db/ReferenceBrowserMain_18_1/LoadItem.aspx?Member=P%3aDevExpress.Xpf.Scheduling.DayView.Days&Template=MemberPropertyTopic">DevExpress.Xpf.Scheduling.DayView.Days</a> property. <br>The project handles the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulingSchedulerControl_VisibleIntervalsChangedtopic">SchedulerControl.VisibleIntervalsChanged</a> event to adjust visible dates if a view's visible intervals are changed with a method other than the navigation commands.<br><br><br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-hide-non-working-days-in-the-day-view-using-custom-commands-and-key-handlers-t608137/17.2.5+/media/e3efa9a1-e7d4-40dd-a9f2-cf783f9d2e7f.png"><br><br>

<br/>


