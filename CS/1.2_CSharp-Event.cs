//Event:
//

//Declare a event
//
//Declare a delegate type
public delegate void EvenHandler(Sender sender, myEventArgs e);

public class myEventArgs:EventArgs
{

}

public class Sender
{
    private EvenHandler eventhandler; //Declare a delegate field
    //Declare a event
    public event EvenHandler Event
    {
        add
        {
            this.eventhandler += value;
        }
        remove 
        {
            this.eventhandler -= value;
        }
    }

    //or 
    public event EvenHandler Event; //omit eventhandler (is not field)
    // if delete event, Event would be delegate field so that it can be invoked by others Sender object (sender2.Event.invoke(sender,e);)

    //Trigger event
    protected void OnTrigger() //event must be triggered by event owner: protected modify OnTrigger and Invoke(this,e)
    {
        if (eventhandler != null)
        {
            myEventArgs e = new myEventArgs();
            this.eventhandler.Invoke(this,e); //run delegate
        }

        //or
        if (this.Event != null)
        {
            myEventArgs e = new myEventArgs();
            this.Event.Invoke(this, e); //run delegate
        }// use Event event instead of eventhandler delegate field
    }
}

Sender sender = new Sender();
Response response = new response();
sender.Event += response.EventAction;   //equal: sender.eventhandler = new EvenHandler(response.EventAction);

sender.OnTrigger(); //Trigger event

public class Response
{
    public void EventAction(Sender sender, EventArgs e)
    {
        Console.WriteLine("Hello World");
    }
}

//Using event
//
public partial class Form
{
    public Form() //class constructor
    {
        this.button.Click += this.ButtonClicked;
        this.button.Click += this.ButtonClicking; //one event to multi event handler

        //or
        this.button.Click += new EventHander(this.ButtonClicked); // EventHander is a delegate

        //or
        this.button.Click += delegate(object sender, EventArgs e) {
            Console.WriteLine("Hello World")
        } //anonymous

        //or
        this.button.Click += (object sender, EventArgs e) => {
            Console.WriteLine("Hello World")
        } //lambda

        //or
        this.button.Click += (sender, e) => {
            Console.WriteLine("Hello World")
        } //lambda light 
    }

    private void ButtonClicked(object sender, EventArgs e)
    {
        if (sender == this.button)
        {
            Console.WriteLine("Hello World")
        }

        if (sender == this.button_1)
        {
            Console.WriteLine("Hello World 1")    //one event handler to multi event
        }
    }

    private void ButtonClicking(object sender, EventArgs e)
    {
        Console.WriteLine("Hello World")
    }

}