using System;

public class DataValueSavable<T> where T : IComparable<T>
{
    public event Action<T> OnChangeValue;
    
    protected T _value;
    private bool _isLoaded;
    
    protected readonly string SaveKey;

    protected DataValueSavable(string saveKey)
    {
        SaveKey = saveKey;
    }

    public T Value
    {
        get
        {
            if(!_isLoaded)
                Load();
            
            return _value;
        }

        set
        {
            _value = value;
            OnChangeValue?.Invoke(_value);
        }
    }

    protected virtual void Load()
    {
        _isLoaded = true;
    }

    public virtual void Save(){}
}