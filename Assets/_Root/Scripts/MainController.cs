using Ui;
using Game;
using Profile;
using UnityEngine;
using Features.Shed;
<<<<<<< Updated upstream
=======
using Features.Fight;
using Features.Rewards;
>>>>>>> Stashed changes

internal class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private MainMenuController _mainMenuController;
    private SettingsMenuController _settingsMenuController;
    private ShedController _shedController;
    private GameController _gameController;
<<<<<<< Updated upstream
=======

    private ShedContext _shedContext;
>>>>>>> Stashed changes


    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _settingsMenuController?.Dispose();
        _shedController?.Dispose();
        _gameController?.Dispose();

        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _settingsMenuController?.Dispose();
                _shedController?.Dispose();
                _gameController?.Dispose();
                break;
            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                _shedController?.Dispose();
                _gameController?.Dispose();
                break;
            case GameState.Shed:
                _shedController = new ShedController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                _settingsMenuController?.Dispose();
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer);
<<<<<<< Updated upstream
                _settingsMenuController?.Dispose();
                _mainMenuController?.Dispose();
                _shedController?.Dispose();
=======
                _startFightController = new StartFightController(_placeForUi, _profilePlayer);
>>>>>>> Stashed changes
                break;
            default:
                _mainMenuController?.Dispose();
                _settingsMenuController?.Dispose();
                _gameController?.Dispose();
                _shedController?.Dispose();
                break;
        }
    }
<<<<<<< Updated upstream
=======

    private void DisposeChildObjects()
    {
        _mainMenuController?.Dispose();
        _settingsMenuController?.Dispose();
        _rewardController?.Dispose();
        _startFightController?.Dispose();
        _fightController?.Dispose();
        _gameController?.Dispose();

        _shedContext?.Dispose();
    }
>>>>>>> Stashed changes
}
