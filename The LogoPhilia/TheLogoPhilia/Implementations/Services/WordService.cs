using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheLogoPhilia.Entities;
using TheLogoPhilia.Interfaces.IRepositories;
using TheLogoPhilia.Interfaces.IServices;
using TheLogoPhilia.Models;

namespace TheLogoPhilia.Implementations.Services
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;

        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public async Task<BaseResponse<WordViewModel>> CreateWord(CreateWordRequestModel model)
        {
           var word = _wordRepository.AlreadyExists(L=> L.TheWord == model.TheWord);
           if(word) return new BaseResponse<WordViewModel>
           {
                 Message = "Word Already Exists",
                 Success = false,
           };
           var newWord = new Word
           {
               
                AmericanEnglishAlternateSpelling = model.AmericanEnglishAlternateSpelling,
                BritishEnglishAlternateSpelling = model.BritishEnglishAlternateSpelling,
                LanguageOfOriginId = model.LanguageOfOriginId,
                WordAudio = model.WordAudio,
                TheWord = model.TheWord,
                Meaning =model.Meaning,
                WordAlternatePronunciation = model.WordAlternatePronunciation,
                PartOfSpeech = model.PartOfSpeech,
                BritishOrAmerican = model.BritishOrAmerican
           };
           await _wordRepository.Create(newWord);
           return new BaseResponse<WordViewModel>
           {
             Message = "Successful Creation Of Word",
             Success = true,
             Data = new WordViewModel
             {
                 TheWordId = newWord.Id,
                 TheWord = newWord.TheWord,
                 AmericanEnglishAlternateSpelling = newWord.AmericanEnglishAlternateSpelling,
                 BritishEnglishAlternateSpelling = newWord.BritishEnglishAlternateSpelling,
                 LanguageOfOriginId = newWord.LanguageOfOriginId,
                 LanguageOfOriginName = newWord.LanguageOfOrigin.LanguageOfOriginName,
                 Meaning = newWord.Meaning,
                 WordAlternatePronunciation = newWord.WordAlternatePronunciation,
                 WordAudio = newWord.WordAudio,
                 BritishOrAmerican = newWord.BritishOrAmerican,
             }
           };
        }

        public async Task<bool> Delete( int Id)
        {
            var word = await _wordRepository.Get(Id);
            if(word==null) return false;
            word.IsDeleted = true;
            _wordRepository.SaveChanges();
            return true;
            
        }

        public async Task<BaseResponse<IEnumerable<WordViewModel>>> GetAll()
        {
            var words = await _wordRepository.GetWords();
            if (words==null) return new BaseResponse<IEnumerable<WordViewModel>>
            {
                Message = "Error!",
                 Success = false,

            };
            var wordsReturned = words.Select(newWord=> new WordViewModel
            {
                TheWordId = newWord.Id,
                 TheWord = newWord.TheWord,
                 AmericanEnglishAlternateSpelling = newWord.AmericanEnglishAlternateSpelling,
                 BritishEnglishAlternateSpelling = newWord.BritishEnglishAlternateSpelling,
                 LanguageOfOriginId = newWord.LanguageOfOriginId,
                 LanguageOfOriginName = newWord.LanguageOfOrigin.LanguageOfOriginName,
                 Meaning = newWord.Meaning,
                 WordAlternatePronunciation = newWord.WordAlternatePronunciation,
                 WordAudio = newWord.WordAudio,
                 BritishOrAmerican = newWord.BritishOrAmerican,
             }).ToList();
             return new BaseResponse<IEnumerable<WordViewModel>>
             {
                Message = "Words Retrieved!",
                 Success = true,
                 Data= wordsReturned,
             };
        }

        public  async Task<BaseResponse<WordViewModel>> GetWord( int Id)
        {
          var word = await _wordRepository.GetWord(Id);
            if(word == null) return new BaseResponse<WordViewModel>
            {
               Message= "Error!",
               Success = false,
            };
            return new BaseResponse<WordViewModel>
            {
               Message = "Successful Retrieval",
               Success = true,
               Data = new WordViewModel
               {
                    TheWordId = word.Id,
                 TheWord = word.TheWord,
                 AmericanEnglishAlternateSpelling = word.AmericanEnglishAlternateSpelling,
                 BritishEnglishAlternateSpelling = word.BritishEnglishAlternateSpelling,
                 LanguageOfOriginId = word.LanguageOfOriginId,
                 LanguageOfOriginName = word.LanguageOfOrigin.LanguageOfOriginName,
                 Meaning = word.Meaning,
                 WordAlternatePronunciation = word.WordAlternatePronunciation,
                 WordAudio = word.WordAudio,
                 BritishOrAmerican = word.BritishOrAmerican
               }
            };
        }

        public async Task<BaseResponse<IEnumerable<WordViewModel>>> Search(string SearchText)
        {
           var searchResult = await _wordRepository.Search(SearchText);
           return new BaseResponse<IEnumerable<WordViewModel>>
            {
                Data =searchResult,
                Message= "Here Is Your Search Result",
                Success = true,

            };
        }

        public async Task<BaseResponse<WordViewModel>> UpdateWord( int Id, UpdateWordRequestModel model)
        {
           var word = await _wordRepository.GetWord(Id);
           if(word == null) return new BaseResponse<WordViewModel>
           {
              Message ="Retrieval Failed",
              Success = false,
           };
           word.AmericanEnglishAlternateSpelling = word.AmericanEnglishAlternateSpelling ?? model.AmericanEnglishAlternateSpelling;
           word.BritishEnglishAlternateSpelling = word.BritishEnglishAlternateSpelling ?? model.BritishEnglishAlternateSpelling;
           word.WordAlternatePronunciation = word.WordAlternatePronunciation ?? model.WordAlternatePronunciation;
          word.WordAlternatePronunciation = word.WordAlternatePronunciation ?? model.WordAlternatePronunciation;
         word.Meaning = word.Meaning ?? model.Meaning;
         word.TheWord = word.TheWord ?? model.TheWord;
           await _wordRepository.Update(word);
           return new BaseResponse<WordViewModel>
           {
               Message = "Update Successful",
               Success =true,
               Data = new WordViewModel
               {
                    TheWordId = word.Id,
                 TheWord = word.TheWord,
                 AmericanEnglishAlternateSpelling = word.AmericanEnglishAlternateSpelling,
                 BritishEnglishAlternateSpelling = word.BritishEnglishAlternateSpelling,
                 LanguageOfOriginId = word.LanguageOfOriginId,
                 LanguageOfOriginName = word.LanguageOfOrigin.LanguageOfOriginName,
                 Meaning = word.Meaning,
                 WordAlternatePronunciation = word.WordAlternatePronunciation,
                 WordAudio = word.WordAudio,
                 BritishOrAmerican = word.BritishOrAmerican,
               }
           };
        }
    }
}