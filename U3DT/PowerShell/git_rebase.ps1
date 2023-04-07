$working_branch = git branch --show-current
git add .
git commit -m "U3DT Auto Commit Message: Rebase with main"
git switch main
git pull
git switch $working_branch
git rebase main