using System;
using UnityEngine;
using Random = System.Random;

namespace Hints
{
    public class HintController : MonoBehaviour
    {
        public int ID;
        public float X;
        public float Y;
        public bool IsAdministrative;
        public string Message;
        public string AuthorToken;
        public DateTime Created;
        public bool LikedByMe;
        public bool IsMine;


        public void InitFromMapping(HintGet hint)
        {
            ID = hint.id;
            X = hint.x;
            Y = hint.y;
            IsAdministrative = hint.is_administrative;
            Message = hint.message;
            AuthorToken = hint.author_token;
            Created = hint.created;
            LikedByMe = hint.liked_by_me;
            IsMine = hint.is_mine;
        }
        
        public void InitFromMapping(HintCreate hint)
        {
            ID = new Random().Next();
            X = hint.x;
            Y = hint.y;
            IsAdministrative = false;
            Message = hint.message;
            AuthorToken = hint.author_token;
            Created = DateTime.Now;
            LikedByMe = true;
            IsMine = true;
        }

        public string GetHintMessage()
        {
            return Message;
        }
    }
}