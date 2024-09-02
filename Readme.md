<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128655992/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T608137)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Scheduler - Hide Non-Working Days in the Day View

This example hides non-working days (Saturday and Sunday) from the [Day View](https://docs.devexpress.com/WPF/119204/controls-and-libraries/scheduler/views/day-view) and does not allow users to navigate to these days.

![image](./media/e3efa9a1-e7d4-40dd-a9f2-cf783f9d2e7f.png)

## Implementation Details

1. Specify the [DayView.Days](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.DayView.Days) property to display a custom set of days.

2. Process the following user navigation types:

   * Left and right arrow keys — Attach the [KeyToCommand](https://docs.devexpress.com/WPF/DevExpress.Mvvm.UI.KeyToCommand) behavior to the Scheduler.
   * UI navigation — Use the [SchedulerControl.Commands](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.Commands) property to replace default commands executed when a user uses the Scheduler UI for navigation.

3. Handle the [SchedulerControl.VisibleIntervalsChanged](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.VisibleIntervalsChanged) event to adjust visible dates when visible view intervals are changed.

## Files to Review

* [MainWindow.xaml](./CS/NavigateCommandExample/MainWindow.xaml)
* [MainViewModel.cs](./CS/NavigateCommandExample/ViewModel/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/NavigateCommandExample/ViewModel/MainViewModel.vb))

## Documentation

* [Day View](https://docs.devexpress.com/WPF/119204/controls-and-libraries/scheduler/views/day-view)
* [Navigation](https://docs.devexpress.com/WPF/119418/controls-and-libraries/scheduler/navigation)
* [SchedulerControl.VisibleIntervalsChanged](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.VisibleIntervalsChanged)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-hide-non-working-days-in-day-view&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-hide-non-working-days-in-day-view&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
