import utilities as util

# Powershell Files:
git_rebase = "git_rebase.ps1"
git_refresh = "git_refresh.ps1"
git_publish = "git_publish.ps1"
git_squash_new = "git_squash_new.ps1"
git_squash_current = "git_squash_current.ps1"
auto_commit_message = "U3DT Auto Commit Message:"

def menu():
    util.menu_title("U3DT Git Menu")
    util.menu_option("1", "Git Commit", "Commits all changes")
    util.menu_option("2", "Git Push", "Pushes Working Branch to origin")
    util.menu_option("3", "New Branch", "Creates new branch from origin/main")
    util.menu_option("4", "Publish Branch", "Publish Branch to origin")
    util.menu_option("5", "Rebase Branch", "Performs Rebase with origin/main")
    util.menu_option("6", "Sqaush New", "Squash Merge into new branch")
    util.menu_option("7", "Squash Current", "Squash Merge into current branch")
    util.menu_option("8", "Git Clean", "Deletes All Branches Except main")
    util.menu_option("0", "Exit Menu", "Return to main menu")
    response = util.get_response("Select an option: ")

    if (response == 1):
        message = util.get_response("Enter commit message: ", "string")
        git_commit(message)
    elif (response == 2):
        git_push()
    elif (response == 3):
        new_branch()
    elif (response == 4):
        git_publish()
    elif (response == 5):
        git_rebase()
    elif (response == 6):
        git_squash(1)
    elif (response == 7):
        git_squash(2)
    elif (response == 8):
        git_refresh_environment()

    util.open_menu()


def git_branch_types(type = ["feature", "spike", "bug-fix", "hot-fix"]):
    util.menu_title("Set Branch Type")
    i = 1
    for t in type:
        util.menu_option(str(i), str(t))
        i += 1
    util.menu_option("0", "Exit Menu", "Return to main menu")
    response = util.get_response("Select an option: ")
    if (response == 0):
        return None
    else:
        index = response - 1
        branch_type = util.concatenate([str(type[index]),"/"],"")
        return branch_type

def new_branch():
    util.clear()
    branch_type = git_branch_types()
    if (branch_type is None):
        util.open_menu("git")
    else:
        branch_name = util.get_response(f"Branch Name: { branch_type }", "string")
        branch_name = util.concatenate([branch_type, branch_name],"").replace(" ","_")
        util.run_command("git switch main")
        util.run_command("git pull")
        util.run_command(f"git checkout -b { branch_name } main")

def git_pull():
    util.run_command("git pull")

def git_commit(message):
    util.run_command("git add .") 
    util.run_command(f'git commit -m "U3DT:  { message }"')

def git_rebase():
    util.run_powershell(f"{ git_rebase }")

def git_push():
    git_commit(f"{auto_commit_message} pushing branch to origin")
    util.run_command("git push")

def git_publish():
    util.run_powershell("git_publish")

def git_leave_branch(commit_message = "switching to different branch"):
    git_commit(commit_message)

def git_diff():
    util.run_command("git diff --name-only")

def git_squash(type = 1):
    if (type == 1):
        util.run_powershell(f"{ git_squash_new }")
    else:
        util.run_powershell(f"{ git_squash_current }")
    
def git_refresh_environment():
    util.run_powershell(f"{ git_refresh }")

util.clear()
menu()