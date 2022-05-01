class Counter
{
  private int _count;
  private String _name;

  public String getName()
  {
    return _name;
  }
  public void setName(String name)
  {
    _name = name;
  }

  public int getTicks()
  {
    return _count;
  }

  public void Increment()
  {
    _count = _count + 1;
  }

  public void Reset()
  {
    _count = 0;
  }
}

class Clock
{
  Counter _hours = new Counter();
  Counter _minutes = new Counter();
  Counter _seconds = new Counter();
  
  public void Tick()
  {
    _seconds.Increment();
    if(_seconds.getTicks() > 59)
    {
      _seconds.Reset();
      _minutes.Increment();
      if(_minutes.getTicks() > 59)
      {
        _minutes.Reset();
        _hours.Increment();
        if(_hours.getTicks() > 23)
        {
          _hours.Reset();
        }
      }
    }
  }

  public void Reset()
  {
    _hours.Reset();
    _minutes.Reset();
    _seconds.Reset();
  }

  public String getTime()
  {
    return _hours.getTicks() + ":" + _minutes.getTicks() + ":" + _seconds.getTicks();
  }
}

public class Program{
  public static void main(String[] args)
  {
    Clock clock = new Clock();
    //Testing intialisation of the clock
    System.out.println("Initialise Clock...");
    System.out.println("Experceted Output: 0:0:0");
    System.out.println("Actual output:     " + clock.getTime());
    System.out.println();
    
    //Testing seconds
    for(int i = 0; i < 59; i++)
    {
      clock.Tick();
    }
    
    System.out.println("Seconds...");
    System.out.println("Experceted Output: 0:0:59");
    System.out.println("Actual output:     " + clock.getTime());
    System.out.println();
    
    //Testing seconds turning into minutes
    clock.Tick();
    System.out.println("One second later...");
    System.out.println("Experceted Output: 0:1:0");
    System.out.println("Actual output:     " + clock.getTime());
    System.out.println();
    
    //Testing minutes
    clock.Reset();
    for(int i = 0; i < 3599; i++)
    {
      clock.Tick();
    }
    
    System.out.println("Minutes...");
    System.out.println("Experceted Output: 0:59:59");
    System.out.println("Actual output:     " + clock.getTime());
    System.out.println();
    
    //Testing minutes turning into hours
    clock.Tick();
    System.out.println("One second later...");
    System.out.println("Experceted Output: 1:0:0");
    System.out.println("Actual output:     " + clock.getTime());
    System.out.println();
    
    //Testing hours
    clock.Reset();
    for(int i = 0; i < 86399; i++)
    {
      clock.Tick();
    }
    
    System.out.println("Hours...");
    System.out.println("Experceted Output: 23:59:59");
    System.out.println("Actual output:     " + clock.getTime());
    System.out.println();
    
    //Testing 24 hours
    clock.Tick();
    System.out.println("One second later...");
    System.out.println("Experceted Output: 0:0:0");
    System.out.println("Actual output:     " + clock.getTime());
    System.out.println();
    
    //Random time then Reset
    for(int i = 0; i < 85400; i++)
    {
      clock.Tick();
    }
    
    System.out.println("Random Time...");
    //Time calculations:
    //85400 / 3600 = 23h
    //85400 - 23*3600 = 2600s / 60 = 43m
    //2600 - 43*60 = 20s
    System.out.println("Experceted Output: 23:43:20");
    System.out.println("Actual output:     " + clock.getTime());
    System.out.println();
    
    clock.Reset();
    System.out.println("Reset...");
    System.out.println("Experceted Output: 0:0:0");
    System.out.println("Actual output:     " + clock.getTime());
    System.out.println();
  }
}
