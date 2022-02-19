public class Param
{
    /* it definitely makes since to make param its own class to store potential metadata
    in addition to what I have below. not sure if this is the exact setup we want though
    */
    public int currentValue;
    public int defaultValue;
    public string name;
    public int increment;
    public Param(int currentValue, int defaultValue, string name, int increment) {
        this.currentValue = currentValue;
        this.defaultValue = defaultValue;
        this.name = name;
        this.increment = increment;
    }

    public Param(int defaultValue, string name) {
        this.currentValue = defaultValue;
        this.defaultValue = defaultValue;
        this.name = name;
        this.increment = 1;
    }

    void setValue(int newValue) {
        this.currentValue = newValue;
    }

    int getDefault() {
        return this.defaultValue;
    }

    int getValue() {
        return this.currentValue;
    }

    int getIncrement() {
        return this.increment;
    }

    void returnToDefault() {
        this.currentValue = this.defaultValue;
    }

}