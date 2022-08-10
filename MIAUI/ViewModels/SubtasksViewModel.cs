﻿using MIAUI.Model;

namespace MIAUI.ViewModels;

[INotifyPropertyChanged]
[QueryProperty(nameof(Task), "Task")]
[QueryProperty(nameof(DetailsInfo), "Details")]
public partial class SubtasksViewModel
{
    public SubtasksViewModel()
    {
        //Details = detailsInfo;
    }

    [ObservableProperty]
    Model.Task task;

    [ObservableProperty]
    int id;

    [ObservableProperty]
    string detailsInfo;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    void SaveDetails()
    {
        //Details.Clear();
        if (string.IsNullOrWhiteSpace(DetailsInfo))
            return;
        //add TaskName
        Task.Details = DetailsInfo;
        App.TaskRepo.UpdateDetails(Task);
        var taskList = App.TaskRepo.GetAllTasks();
        //Details.Add(DetailsInfo);
        //DetailsInfo = string.Empty;
    }

}
