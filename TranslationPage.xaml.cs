using System;
using Microsoft.Maui.Controls;

namespace AIService
{
    public partial class TranslationPage : ContentPage
    {
        private TranslationService translationService = new TranslationService();
        private string targetLanguage = "en";
        public TranslationPage()
        {
            InitializeComponent();
        }

        private async void TranslateButton_Clicked(object sender, EventArgs e)
        {
            string textToTranslate = textToTranslateEditor.Text;
            string sourceLanguage = "en"; // Default source language

            if (!string.IsNullOrWhiteSpace(textToTranslate) && !string.IsNullOrWhiteSpace(sourceLanguage) && !string.IsNullOrWhiteSpace(targetLanguage))
            {
                string translation = await translationService.TranslateAsync(textToTranslate, sourceLanguage, targetLanguage);

                translationResultLabel.Text = translation;
            }
            else
            {
                translationResultLabel.Text = "Please fill in all fields.";
            }
        }

        private async void TranslateInReverseButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                string translatedText = translationResultLabel.Text;
                string originalTargetLanguage = "fr";
                string reverseTranslation = await translationService.TranslateAsync(translatedText, originalTargetLanguage, "en");

                reverseTranslationLabel.Text = reverseTranslation;
            }
            catch (Exception ex)
            {

            }
        }

        private void french_Tapped(object sender, EventArgs e)
        {
            targetLanguage = "fr";
        }

        private void dutch_Tapped(object sender, EventArgs e)
        {
            targetLanguage = "nl";
        }
    }
}
