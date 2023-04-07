import os
from colorama import init, Fore, Back, Style

def menu_option(index, message, description = None, o_style = Style.NORMAL, o_color = Fore.WHITE):
    option = ""
    item = concatenate(["[",index,"]"],"")
    if (description is None):
        option = concatenate([item, message])
    else:
        option = concatenate([item, message," \t- ", description])
    print(o_style, o_color, option)

def print_message(message, m_style = Style.NORMAL, m_color = Fore.WHITE):
    print(m_style, m_color, message)

def concatenate(string_array, delimiter = " "):
    result = ""
    input_len = len(string_array)
    i = 0
    for s in string_array:
        i += 1
        if (i < input_len):
            result = result + s + delimiter
        else:
            result = result + s
    result = result.replace(f"{delimiter}{delimiter}", f"{delimiter}")
    return result

def menu_title(title, decoration = "*", t_color = Fore.GREEN, t_style = Style.NORMAL):
    banner = ""
    half_banner = ""
    title_line = ""
    for i in enumerate(title):
        banner = concatenate([banner, decoration],"")
        banner = concatenate([banner, decoration],"")
        banner = concatenate([banner, decoration],"")
    banner = concatenate([banner, decoration, decoration],"")
    for i in enumerate(title):
        half_banner = concatenate([half_banner, decoration],"")
    title_line = concatenate([half_banner, title, half_banner])
    print(t_style, t_color, banner)
    print(t_style, t_color, title_line)
    print(t_style, t_color, banner)

def get_response(message, type = "integer"):
    print(Style.NORMAL, Fore.WHITE, "")
    result = ""
    result = input(message)
    try:
        if (type == "integer"):
            result = int(result)
        elif (type == "string"):
            result = str(result)
        else:
            print_error("Invalid Input!", "Unexpected Input type")
    except Exception:
        error_message = concatenate(["Expected input of type:", type])
        print_error("Invalid Input!", error_message)
        get_response(message)
    return result

def clear():
    print(Style.NORMAL, Fore.WHITE, "")
    run_command("cls")

def run_command(cmd):
    try:
        os.system(cmd)
    except Exception:
        print_error(Exception.__name__, Exception.__context__)

def return_command(cmd):
    result = ""
    try:
        result = os.system(cmd)
    except Exception:
        print_error(Exception.__name__, Exception.__context__)
    return result

def print_error(error, message = None, e_style = Style.NORMAL, e_color = Fore.RED):
    result = ""
    if (message is None):
        result = error
    else:
        result = concatenate([error, message],"\n")
    print(e_style, e_color, result)

def open_menu(menu = "menu"):
    run_command(f"python .\\u3dt\\python310\\u3dt_{ menu }.py")

def run_powershell(ps_script):
    ps_dir = ".\\U3DT\\PowerShell\\"
    if (str(ps_script).endswith(".ps1")):
        run_command(f"PowerShell { ps_dir }{ ps_script }")
    else:
        run_command(f"PowerShell { ps_dir }{ ps_script }.ps1")

def list_dir(root_dir, target_dir):
    if (target_dir is None):
        target = root_dir
    else:
        target = concatenate([root_dir, target_dir],"\\")
    return os.listdir(target)

def is_dir(target_dir):
    return os.path.isdir(target_dir)

def is_file(target_dir):
    return os.path.isfile(target_dir)

def copy_file_contents(from_file, to_file):
    try:
        os.popen(f"copy {from_file} {to_file}")
    except Exception:
        print_error(str(Exception.__name__), str(Exception.__context__))

def file_to_array(file, delimiter = ","):
    result = ""
    read_file = open(file, "r")
    for line in read_file: 
        result += line + delimiter
    read_file.close()

    result = result.split(delimiter)
    return result