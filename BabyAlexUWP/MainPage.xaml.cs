using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BabyAlexUWP
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    private async void readText(VoiceGender myGender, string myText)
    {
      MediaElement mediaplayer = new MediaElement();
      using (var speech = new SpeechSynthesizer())
      {
        speech.Voice = SpeechSynthesizer.AllVoices.First(gender => gender.Gender == myGender);
        string ssml = @"<speak version='1.0' " + "xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='en-US'>" + myText + "</speak>";
        SpeechSynthesisStream stream = await speech.SynthesizeSsmlToStreamAsync(ssml);
        mediaplayer.SetSource(stream, stream.ContentType);
        mediaplayer.Play();
      }
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
      // The string to speak with SSML customizations.
      /*string Ssml =
          @"<speak version='1.0' " +
          "xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='en-US'>" +
          "Hello <prosody contour='(0%,+80Hz) (10%,+80%) (40%,+80Hz)'>World</prosody> " +
          "<break time='500ms'/>" +
          "Goodbye <prosody rate='slow' contour='(0%,+20Hz) (10%,+30%) (40%,+10Hz)'>World</prosody>" +
          "</speak>";*/

      // Activities for 0 to 6 month-old Babies
      // The feeling of being loved help develops your baby’s brain.

      string babyAlex = "I am baby Alex" + "<break time='1000ms'/>";
      babyAlex += "I am 3 months old" + "<break time='1000ms'/>";
      babyAlex += "My mommy and daddy love me very much" + "<break time='1000ms'/>";
      babyAlex += "I am a happy baby" + "<break time='1000ms'/>";

      readText(VoiceGender.Male, babyAlex);

      string mommyR = "Hello, baby Alex" + "<break time='1000ms'/>";
      mommyR += "Are you having fun?" + "<break time='1000ms'/>";

      readText(VoiceGender.Female, mommyR);

    }
  }
}
