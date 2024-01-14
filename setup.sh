#!/bin/bash

CRUNCHI_VOTE_DIR=$(pwd)

cd "$CRUNCHI_VOTE_DIR"

docker-compose -f "docker-compose.yaml" up -d --build

cd "$CRUNCHI_VOTE_DIR/backend/src/CrunchiVote.Infrastructure"

if [ -d "Migrations" ]; then
    rm -rf Migrations
fi

dotnet ef migrations add init -c Context
dotnet ef database update -c Context


cd "$CRUNCHI_VOTE_DIR/backend/src/CrunchiVote.Identity"

if [ -d "Migrations" ]; then
    rm -rf Migrations
fi

dotnet ef migrations add init -c IdentityContext
dotnet ef database update -c IdentityContext

cd "$CRUNCHI_VOTE_DIR/backend/src/CrunchiVote.Api"
dotnet run

cd "$CRUNCHI_VOTE_DIR/frontend/crunchivote"
npm i
npm start
