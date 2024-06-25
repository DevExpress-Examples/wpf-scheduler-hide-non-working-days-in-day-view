<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128655992/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T608137)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/NavigateCommandExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/NavigateCommandExample/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/NavigateCommandExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/NavigateCommandExample/MainWindow.xaml.vb))
* [MainViewModel.cs](./CS/NavigateCommandExample/ViewModel/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/NavigateCommandExample/ViewModel/MainViewModel.vb))
<!-- default file list end -->
# How to hide non-working days in the Day view using custom commands and key handlers


This example demonstrates how to restrict the <a href="http://help.devexpress.com/#WPF/CustomDocument119204">Day View</a> navigation to display seven days, Saturday and Sunday excluded. <br>To accomplish this, the project implements a custom <a href="https://docs.devexpress.com/WPF/113865/mvvm-framework/behaviors/predefined-set/keytocommand">KeyToCommand behavior</a> to handle the left and right arrow keys. Navigation commands execute custom methods defined in ViewModel. Commands are replaced with methods using the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulingSchedulerControl_Commandstopic">SchedulerControl.Commands </a>property and <a href="https://documentation.devexpress.com/WPF/115776/MVVM-Framework/DXBinding/DXCommand">DXCommand</a> binding introduced in the DevExpress MVVM Framework . <br>A custom set of days is assigned to the <a href="https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.DayView.Days">DevExpress.Xpf.Scheduling.DayView.Days</a> property. <br>The project handles the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulingSchedulerControl_VisibleIntervalsChangedtopic">SchedulerControl.VisibleIntervalsChanged</a> event to adjust visible dates if a view's visible intervals are changed with a method other than the navigation commands.<br><br><br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-hide-non-working-days-in-the-day-view-using-custom-commands-and-key-handlers-t608137/17.2.5+/media/e3efa9a1-e7d4-40dd-a9f2-cf783f9d2e7f.png"><br><br>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-hide-non-working-days-in-day-view&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-hide-non-working-days-in-day-view&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
