public interface IPickable{
	void Take(PlayerController player);
	void Take(EnemyController enemy);
	void Deactivate();
	void Activate();
}
