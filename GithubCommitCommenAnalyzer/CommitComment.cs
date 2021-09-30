using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;

namespace GithubCommitCommenAnalyzer
{
    public class CommitComment
    {
        public String Comments
        {
            get
            {
                return _commentList.LastOrDefault();
            }
            set
            {
                _commentList.add(value);
            }
        }

        public CircularLinkList<string> AllCommentList { get { return _commentList; } }



        CircularLinkList<string> _commentList = new CircularLinkList<string>();

    }
}
