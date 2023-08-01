using System.ComponentModel;

namespace MancalaAssessment.Models;

public class PitData : INotifyPropertyChanged
{
	private int _stones;
    public event PropertyChangedEventHandler? PropertyChanged;
    public int Stones
	{
		get { return _stones; }
        set
        {
            _stones = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Stones)));
        }
	}

	private int _ownerPlayer;

	public int OwnerPlayer
	{
		get { return _ownerPlayer; }
        set
        {
            _ownerPlayer = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OwnerPlayer)));
        }
	}

    public PitData(int stones, int ownerPlayer)
    {
        _ownerPlayer = ownerPlayer;
        _stones = stones;
    }


}