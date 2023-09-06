using System;
using Microsoft.Maui.Controls;

namespace AIService
{
    public partial class TranslationPage : ContentPage
    {
        private TranslationService translationService = new TranslationService(); // Create an instance of your TranslationService

        public TranslationPage()
        {
            InitializeComponent();
        }

        private async void TranslateButton_Clicked(object sender, EventArgs e)
        {
            string textToTranslate = textToTranslateEditor.Text;
            string sourceLanguage = sourceLanguagePicker.SelectedItem as string;
            string targetLanguage = targetLanguagePicker.SelectedItem as string;

            if (!string.IsNullOrWhiteSpace(textToTranslate) && !string.IsNullOrWhiteSpace(sourceLanguage) && !string.IsNullOrWhiteSpace(targetLanguage))
            {
                // Call your TranslationService to get the translation
                string translation = await translationService.TranslateAsync(textToTranslate, sourceLanguage, targetLanguage);

                // Update the translationResultLabel with the translation result
                translationResultLabel.Text = translation;
            }
            else
            {
                translationResultLabel.Text = "Please fill in all fields.";
            }
        }
    }
}
