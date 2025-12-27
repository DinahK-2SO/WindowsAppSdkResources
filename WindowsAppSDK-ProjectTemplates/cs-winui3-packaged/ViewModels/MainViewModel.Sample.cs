using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BlankApp.Models;
using BlankApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace BlankApp.ViewModels;

/// <summary>
/// ViewModel for the main page.
/// Demonstrates MVVM pattern, property change notifications, and command implementation.
/// </summary>
public class MainViewModel : ObservableObject
{
    private readonly ILogger<MainViewModel> _logger;
    private readonly IUserService _userService;
    
    private string _title;
    private string _statusMessage;
    private bool _isLoading;
    private User? _currentUser;

    public MainViewModel(ILogger<MainViewModel> logger, IUserService userService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        
        // Initialize commands
        LoadDataCommand = new AsyncRelayCommand(LoadDataAsync, () => !IsLoading);
        RefreshCommand = new AsyncRelayCommand(RefreshAsync, () => !IsLoading);
        
        // Set defaults
        _title = "Welcome";
        _statusMessage = string.Empty;
    }

    #region Properties

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (SetProperty(ref _isLoading, value))
            {
                // Notify commands to re-evaluate CanExecute
                LoadDataCommand.NotifyCanExecuteChanged();
                RefreshCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public User? CurrentUser
    {
        get => _currentUser;
        set => SetProperty(ref _currentUser, value);
    }

    #endregion

    #region Commands

    public IAsyncRelayCommand LoadDataCommand { get; }
    public IAsyncRelayCommand RefreshCommand { get; }

    #endregion

    #region Methods

    /// <summary>
    /// Loads user data from the service.
    /// Demonstrates async operations, error handling, and property updates.
    /// </summary>
    public async Task LoadDataAsync()
    {
        _logger.LogTrace("Entering LoadDataAsync");
        var sw = Stopwatch.StartNew();
        
        try
        {
            IsLoading = true;
            StatusMessage = "Loading...";

            // Call service layer
            var user = await _userService.GetUserAsync(1);
            
            if (user != null)
            {
                CurrentUser = user;
                Title = $"Welcome, {user.Name}!";
                StatusMessage = "Data loaded successfully";
            }
            else
            {
                StatusMessage = "User not found";
            }
            
            _logger.LogInformation("LoadDataAsync completed in {Duration}ms", 
                sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "LoadDataAsync failed after {Duration}ms", 
                sw.ElapsedMilliseconds);
            StatusMessage = "Error loading data";
        }
        finally
        {
            IsLoading = false;
        }
    }

    /// <summary>
    /// Refreshes the current data.
    /// </summary>
    public async Task RefreshAsync()
    {
        _logger.LogTrace("Entering RefreshAsync");
        
        // Clear current data
        CurrentUser = null;
        Title = "Welcome";
        
        // Reload
        await LoadDataAsync();
    }

    /// <summary>
    /// Validates user input.
    /// Demonstrates validation logic in ViewModel.
    /// </summary>
    public bool ValidateInput(string input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }

    #endregion
}

