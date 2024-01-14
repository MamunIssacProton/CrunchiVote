#!/bin/bash

CRUNCHI_VOTE_DIR=$(pwd)

cd "$CRUNCHI_VOTE_DIR"

docker-compose -f "docker-compose.yaml" up -d --build

cd "$CRUNCHI_VOTE_DIR/backend/src/CrunchiVote.Infrastructure"

dotnet ef migrations add init -c Context
dotnet ef database update -c Context


cd "$CRUNCHI_VOTE_DIR/backend/src/CrunchiVote.Identity"

dotnet ef migrations add init -c IdentityContext
dotnet ef database update -c IdentityContext
