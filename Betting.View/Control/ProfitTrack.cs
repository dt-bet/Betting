using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows;
using System.Windows.Controls;
using UtilityHelper;

namespace Betting.View
{

    public class ProfitTrack: Control
    {
        public override void OnApplyTemplate()
        {
            betTrack = this.GetTemplateChild("BetTrack") as Betting.View.BetTrack;
            //ProfitTrackChanges.OnNext(betTrack);
        }


        public static readonly DependencyProperty ProfitTrackerProperty = DependencyProperty.Register("ProfitTracker", typeof(ProfitTracker), typeof(ProfitTrack), new PropertyMetadata(null,Changed));


        public ProfitTracker ProfitTracker
        {
            get { return (ProfitTracker)GetValue(ProfitTrackerProperty); }
            set { SetValue(ProfitTrackerProperty, value); }
        }
        Dictionary<string, Subject<object>> dict = typeof(ProfitTrack).GetDependencyProperties().ToDictionary(_ => _.Name.Substring(0, _.Name.Length - 8), _ => new Subject<object>());
        private BetTrack betTrack;

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ProfitTrack).Dispatcher.InvokeAsync(() => ((d as ProfitTrack).betTrack).BetTracker = 
            (e.NewValue as ProfitTracker).Bets,System.Windows.Threading.DispatcherPriority.Background);
            //(d as ProfitTrackWrapper).dict[e.Property.Name].OnNext(e.NewValue);
        }


        static ProfitTrack()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProfitTrack), new FrameworkPropertyMetadata(typeof(ProfitTrack)));
        }


        public ProfitTrack()
        {

        }

    }
}
