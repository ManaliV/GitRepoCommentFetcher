using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;

namespace GithubCommitCommenAnalyzer
{
    public class CommentAnalyzercs
    {

        public CommentAnalyzercs(List<CommitComment>comments)
        {
            _comments = new List<CommitComment>(comments);
        }

        public Dictionary<string,int> CountFrequency()
        {
            Dictionary<string, int> frequencyCounter = new Dictionary<string, int>();
            foreach(var comment in _comments)
            {
                CircularLinkList<string> allWordsInComment = comment.AllCommentList;
                Dictionary<string, int> eachCommentWordDictionary = allWordsInComment.CountFrequency();
                frequencyCounter= MergeTwoDictionaries(frequencyCounter, eachCommentWordDictionary);
            }

            return frequencyCounter;
        }

        private Dictionary<string, int> MergeTwoDictionaries(Dictionary<string, int> frequencyCounter, Dictionary<string, int> eachCommentWordDictionary)
        {
            var keyList=eachCommentWordDictionary.Keys.ToList();
            foreach (var key in keyList)
            {
                if (frequencyCounter.ContainsKey(key.ToString()))
                    frequencyCounter[key.ToString()] += eachCommentWordDictionary[key.ToString()];
                else
                    frequencyCounter[key.ToString()] = eachCommentWordDictionary[key.ToString()];
            }

            return frequencyCounter;
        }

        List<CommitComment> _comments = new List<CommitComment>();
    }
}
