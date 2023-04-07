import utilities as util
docs_template = ".\\U3DT\\Templates\\Docs\\docs_template.md"
dev_profile = ".\\dev_profile"

def menu():
    response = None
    util.menu_title("U3DT Docs Menu")
    util.menu_option("1", "Generate")
    util.menu_option("0", "Exit Menu")
    response = util.get_response("Select an option: ")
    if (response == 1):
        util.clear()
        scan_dir(target="\\Code", target_is_file=True)
    else:
        util.open_menu("menu")

def docs_sub_menu():
    response = None
    util.menu_title("U3DT Generate Docs for")
    util.menu_option("1", "Specific File", "Generate Docs for specific file")
    util.menu_option("1", "Directory", "Generate Docs for specific directory")
    util.menu_option("0", "Exit Menu", "Returns to Docs Menu")
    response = util.get_response("Select an option: ")
    if (response == 1):
        scan_dir(target="\\Code", target_is_file=True)  
    elif (response == 2):
        scan_dir(target="\\Code", target_is_file=False)
    else:
        util.clear()
        util.open_menu("docs")

def scan_dir(root_dir = ".\\Assets", target = None, target_is_file = True):
    util.clear()
    util.menu_title("U3DT Scaning Directory")
    if target is None:
        target_path = root_dir
    else:
        target_path = util.concatenate([root_dir, target], "\\")
    sub_dir = util.list_dir(root_dir, target)
    for dir in sub_dir:
        if dir.endswith(".meta"):
            sub_dir.remove(dir)
    i = 1
    for dir in sub_dir:
        util.menu_option(f"{i}", dir)
        i += 1
    util.menu_option("0", "Cancel")
    response = util.get_response("Select an option: ")
    i = response - 1
    selection = sub_dir[i]
    new_dir = util.concatenate([target_path, selection], "\\")
    new_dir = new_dir.replace("\\\\","\\")
    if response == 0:
        menu()
    elif target_is_file and util.is_file(new_dir) == False:
        scan_dir(new_dir)
    else:
        docs_dir = util.concatenate([target_path, "Docs"], "\\")
        target_file_name = selection.split(".")[0] + ".md"
        new_file = util.concatenate([docs_dir, target_file_name], "\\")
        make_dir = False
        if util.is_dir(docs_dir):
            if util.is_file(new_file):
                response = util.get_response(f"File {target_file_name} already exists, Overwrite? y/n... ", "string")
                if response.lower() == "y":
                    make_dir = True
            else:
                make_dir = True
        else:
            make_dir = True
            util.run_command(f"mkdir {docs_dir}")
        if make_dir:
            util.clear()
            util.menu_title("Docs Generation")
            util.copy_file_contents(docs_template, new_file)
            profile = util.file_to_array(dev_profile)
            dev_name = "[name]"
            dev_role = "[role]"
            title = None
            default_title = target_file_name.replace(".md","")
            for line in profile:
                if line.startswith("name="):
                    dev_name = line.split("=")[1].strip()
                elif line.startswith("role="):
                    dev_role = line.split("=")[1].strip()
            response = util.get_response(f"Default Title is: {default_title} use this? y/n...", "string")
            if response.lower() == "n":
              title = util.get_response(f"Enter Title for Doc: ", "string")
            if title is None:
                title = default_title
            util.clear()
            util.menu_title("Docs Generation")
            util.print_message("Note:............................................")
            util.print_message("for line breaks use <br/>")
            util.print_message("for bold text use **text**")
            util.print_message("for italic text use _text_")
            util.print_message("for internal links use [text](path)")
            util.print_message('for external links use <a href="URL">Text</a>')
            util.print_message('for an image use ![image](path)')
            util.print_message(".................................................")
            code_description = util.get_response("Please Write a breif description: ", "string")
            file_name = new_dir.split("\\")[-1]
            file_contents = ""
            read_file = open(docs_template)
            for line in read_file:
                file_contents += line
            read_file.close()
            file_contents = file_contents.replace("[title]", f"_{title}_")
            file_contents = file_contents.replace("_[description]_", f"_{code_description}_")
            file_contents = file_contents.replace("_[name]_", f"_{dev_name}_")
            file_contents = file_contents.replace("_[role]_", f"_{dev_role}_")
            file_contents = file_contents.replace("[location]_", f"[{file_name}]({new_dir})_")
            write_file = open(new_file, "w")
            write_file.write("")
            write_file.write(file_contents)
            write_file.close()
        util.clear()
        menu()


util.clear()
menu()