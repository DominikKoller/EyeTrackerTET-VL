using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;


namespace TETCSharpClient
{
    public static class TETHelper
    {
        //returning and taking GazeManager as input even though it's singleton, so we don't have timing ambiguity in VL
        public static GazeManager Activate(GazeManager gazemanager)
        {
            gazemanager.Activate(GazeManager.ApiVersion.VERSION_1_0, GazeManager.ClientMode.Push);
            return gazemanager;
        }

        public static GazeManager CalibrationStart(GazeManager gazemanager, Int32 numCalibrationPoints, ICalibrationProcessHandler listener)
        {
            GazeManager.Instance.CalibrationStart(Convert.ToInt16(numCalibrationPoints), listener);
            return gazemanager;
        }

        public static GazeManager GetTrackerState(GazeManager gazemanager, out String state)
        {
            state = gazemanager.Trackerstate.ToString();
            return gazemanager;
        }

        // Workaround: VL is very strict in regards to mutablility: Data linked into delegate regions needs to be immutable.
        // Therefore explicetly pipe data from subscribe to unsubscribe. This data we call "TDataForUnsubscribe"
        public static IObservable<TData> CreateObservable<TData, TDataForUnsubscribe>(
            Func<IObserver<TData>, TDataForUnsubscribe> onSubscribe, 
            Action<TDataForUnsubscribe> onUnsubscribe)
        {
            return
              Observable.Create<TData>((observer) =>
              {
                  var dataForUnsubscribe = onSubscribe(observer);
                  return () => { onUnsubscribe(dataForUnsubscribe); };               
              });
        }
    }

    public enum CalibrationNotificationType
    {
        CalibrationStarted,
        CalibrationProgress,
        CalibrationProcessing,
        CalibrationResult
    }

    public enum CalibrationState
    {
        Inactive,
        Calibrating,
        AllDataCollected,
        Computing,
        Done,
        Error
    }

    public enum CalibrationPointState
    {
        Inactive,
        Idle,
        Calibrating
    }
}
