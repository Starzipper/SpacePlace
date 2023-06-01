﻿using SpacePlace.Models;

namespace SpacePlace.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public List<Comment> Comments { get; set; } = new List<Comment>()
        {
            new Comment()
            {
                Poster = "supermastergameplayer23",
                Content = "Just played Tears of the Kingdom today! 100% worth the wait! It's so good!",
                Likes = 21,
                Dislikes = -1,
                Replies = new List<Comment>()
                {
                    new Comment()
                    {
                        Poster = "imAgoofyGooberYEAH",
                        Content = "game of the year 2023 honestly",
                        Likes = 4,
                        Dislikes = 0
                    },
                    new Comment()
                    {
                        Poster = "Sleve McDichael",
                        Content = "oml that game is overrated af. it really isn't that great kid. get better taste",
                        Likes = 1,
                        Dislikes = 8,
                        Replies = new List<Comment>()
                        {
                            new Comment()
                            {
                                Poster = "imAgoofyGooberYEAH",
                                Content = "bad take detected",
                                Likes = 4,
                                Dislikes = 0
                            },
                            new Comment()
                            {
                                Poster = "Beffica Winklesnoot",
                                Content = "L + didn't ask + ratio",
                                Likes = 3,
                                Dislikes = 0
                            },
                            new Comment()
                            {
                                Poster = "supermastergameplayer23",
                                Content = "Well, I think it's great, so I made a post about it. Why are you getting so heated about someone else's opinion?" +
                                "Also, making assumptions about someone's age is literally the most childish thing you can do. If you want to have a genuine discussion about " +
                                "the merits of TOTK, I'd be completely open to that, but please leave the ad hominem out of it :)",
                                Likes = 8,
                                Dislikes = 0
                            },
                            new Comment()
                            {
                                Poster = "needsspeed",
                                Content = "go to bed little Timmy LMFAO",
                                Likes = 1,
                                Dislikes = 0
                            }
                        }
                    }
                }
            },
            new Comment()
            {
                Poster = "needsspeed",
                Content = "yeet"
            }
        };
        public CommentResponse GetComments(CommentRequest request)
        {
            try
            {
                if (request.ID == Guid.Empty)
                {
                    return new CommentResponse()
                    {
                        Comments = Comments,
                        Success = true
                    };
                }

                var comment = Comments.Where(com => com.ID == request.ID).FirstOrDefault();
                if (comment == null)
                {
                    return new CommentResponse()
                    {
                        ID = request.ID,
                        ErrorMessage = "Comment not found.",
                        Success = false
                    };
                }

                return new CommentResponse()
                {
                    ID = comment.ID,
                    Poster = comment.Poster,
                    Content = comment.Content,
                    Likes = comment.Likes,
                    Dislikes = comment.Dislikes,
                    Replies = comment.Replies,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommentResponse()
                {
                    ID = request.ID,
                    ErrorMessage = exception.Message,
                    Success = false
                };
            }
        }
        public CommentResponse PostComment(CommentRequest request)
        {
            try
            {
                var comment = new Comment()
                {
                    ParentID = request.ParentID,
                    Poster = request.Poster,
                    Content = request.Content
                };

                if (request.ParentID == Guid.Empty)
                {
                    Comments.Add(comment);
                }
                else
                {
                    var parentComment = Comments.Where(com => com.ID == request.ParentID).FirstOrDefault();
                    if (parentComment == null)
                    {
                        return new CommentResponse()
                        {
                            ErrorMessage = "Parent comment not found.",
                            Success = false
                        };
                    }
                    parentComment.Replies.Add(comment);
                }

                return new CommentResponse()
                {
                    ID = comment.ID,
                    ParentID = comment.ParentID,
                    Poster = request.Poster,
                    Content = request.Content,
                    Likes = comment.Likes,
                    Dislikes = comment.Dislikes,
                    Replies = comment.Replies,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommentResponse()
                {
                    ErrorMessage = exception.Message,
                    Success = false
                };
            }
        }
        public CommentResponse EditComment(CommentRequest request)
        {
            try
            {
                var index = Comments.FindIndex(com => com.ID == request.ID);
                if (index == -1)
                {
                    return new CommentResponse()
                    {
                        ID = request.ID,
                        ErrorMessage = "Comment not found.",
                        Success = false
                    };
                }
                Comments[index].Content = request.Content;

                return new CommentResponse()
                {
                    ID = request.ID,
                    Poster = request.Poster,
                    Content = request.Content,
                    Likes = request.Likes,
                    Dislikes = request.Dislikes,
                    Replies = request.Replies,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommentResponse()
                {
                    ID = request.ID,
                    ErrorMessage = exception.Message,
                    Success = false
                };
            }
        }
        public CommentResponse DeleteComment(CommentRequest request)
        {
            try
            {
                var comment = Comments.Where(com => com.ID == request.ID).FirstOrDefault();
                if (comment == null)
                {
                    return new CommentResponse()
                    {
                        ID = request.ID,
                        ErrorMessage = "Comment not found.",
                        Success = false
                    };
                }
                Comments.Remove(comment);

                return new CommentResponse()
                {
                    ID = request.ID,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommentResponse()
                {
                    ID = request.ID,
                    ErrorMessage = exception.Message,
                    Success = false
                };
            }
        }
    }
}
