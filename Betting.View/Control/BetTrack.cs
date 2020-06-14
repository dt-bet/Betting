
using System.Windows;
using System.Windows.Controls;


namespace Betting.View
{

    public class BetTrack : Control
    {



        public static readonly DependencyProperty BetTrackerProperty = DependencyProperty.Register("BetTracker", typeof(BetTracker), typeof(BetTrack), new PropertyMetadata(null,Changed));


        public BetTracker BetTracker
        {
            get { return (BetTracker)GetValue(BetTrackerProperty); }
            set { SetValue(BetTrackerProperty, value); }
        }
        // Dictionary<string, Subject<object>> dict = typeof(BetTrack).GetDependencyProperties().ToDictionary(_ => _.Name.Substring(0, _.Name.Length - 8), _ => new Subject<object>());
        //ISubject<Service.BetTracker> subject = new Subject<Service.BetTracker>();
        //private BetTrack betTrack;

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //(d as BetTrack).BetTracker = (e.NewValue) as Service.BetTracker;
            //(d as BetTrack).subject.OnNext(e.NewValue as Service.BetTracker);
        }

        public override void OnApplyTemplate()
        {
            //betTrack = this.GetTemplateChild("BetTrack") as Betting.View.BetTrack;
            //subject.OnNext(betTrack);
        }

        static BetTrack()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BetTrack), new FrameworkPropertyMetadata(typeof(BetTrack)));
        }


        public BetTrack()
        {

        }

    }
}
