#pragma once

#include <string>
#include "anitomy/anitomy/anitomy.h"
#include "atlsafe.h"

std::string convert_to_string(anitomy::string_t input_str);
LPSAFEARRAY convert_to_safe_array(std::vector<std::string> input_array);
extern "C" __declspec(dllexport) LPSAFEARRAY parse_anime_file_name(const wchar_t*	file_name,
																   const wchar_t*	ignored_strings[],
															       const int		ignored_strings_length,
																   const wchar_t*	allowed_delimiters,
																   const bool		parse_episode_number,
																   const bool		parse_episode_title,
																   const bool		parse_file_extension,
																   const bool		parse_release_group);