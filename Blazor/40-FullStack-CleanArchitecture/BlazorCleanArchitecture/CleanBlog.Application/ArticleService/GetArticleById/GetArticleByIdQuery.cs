﻿using CleanBlog.Application.ArticleService.Dtos;
using MediatR;

namespace CleanBlog.Application.ArticleService.GetArticleById;

public sealed class GetArticleByIdQuery : IRequest<ArticleResponseDto?>
{
    private int id;

    public int Id 
    {
        get => id;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Id must be greater than 0");
            }

            id = value;
        }
    }
}
