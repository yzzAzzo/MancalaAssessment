namespace MancalaAssessment.Models;

public class PitData : NotifyBase
{
	private int _stones;

	public int Stones
	{
		get { return _stones; }
        set
        {
            _stones = value;
            OnPropertyChanged();
        }
	}

	private int _ownerPlayer;

	public int OwnerPlayer
	{
		get { return _ownerPlayer; }
        set
        {
            _ownerPlayer = value; 
			OnPropertyChanged();
        }
	}

    public PitData(int stones, int ownerPlayer)
    {
        _ownerPlayer = ownerPlayer;
        _stones = stones;
    }


}