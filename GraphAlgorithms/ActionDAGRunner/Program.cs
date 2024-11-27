// See https://aka.ms/new-console-template for more information

using ActionDAG;

Console.WriteLine("Hello, World!");

var wakeup = new DagBlock("Wakeup", "", () => { Console.WriteLine("Action: Woke up"); });
var stopAlarm = new DagBlock("Stop the Alarm", "", () => { Console.WriteLine("Action: Stopped the alarm"); });
var turnOnBoiler = new DagBlock("Turn on the boiler", "", () => { Console.WriteLine("Action: Turned the boiler on"); });
var haveShower = new DagBlock("Have a Shower", "", () => { Console.WriteLine("Action: Had a Shower"); });
var goToWork = new DagBlock("Go to work", "", () => { Console.WriteLine("Action: Went to work"); });

var dag = new Dag();
dag
    .AddActions(wakeup, stopAlarm, turnOnBoiler, haveShower, goToWork)
    .DependsOn(wakeup, stopAlarm)
    .DependsOn(wakeup, turnOnBoiler)
    .DependsOn(turnOnBoiler, haveShower)
    .DependsOn(haveShower, goToWork)
    .Build()
    .Execute();